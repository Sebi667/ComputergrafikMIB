using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Engine.Core.Scene;
using Fusee.Engine.Core.Effects;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;
using Fusee.Engine.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuseeApp
{
    [FuseeApplication(Name = "Tut11_AssetsPicking", Description = "Yet another FUSEE App.")]
    public class Tut11_AssetsPicking : RenderCanvas
    {
        private SceneContainer _scene;
        private SceneRendererForward _sceneRenderer;
        private ScenePicker _scenePicker;

        //Tires
        private Transform _mainPart;
        private Transform _frontRightTire;
        private Transform _frontLeftTire;
        private Transform _backTires;

        //Turret-Parts
        private Transform TurretBase;
        private Transform TurretBarrel;

        //Picking
        private PickResult _currentPick;
        private float4 _oldColor;

        //Wird im Init verwendet um die transform-Befehle etwas zu verkürzen
        private Transform getTransform(string name)
        {
            return _scene.Children.FindNodes(node => node.Name == name)?.FirstOrDefault()?.GetTransform();
        }
        // Init is called on startup. 
        public override void Init()
        {
            RC.ClearColor = new float4(0.8f, 0.9f, 0.7f, 1);
            //Hands over the Fusee-File
            _scene = AssetStorage.Get<SceneContainer>("Humvee.fus");
            // Create a scene renderer holding the scene above
            _sceneRenderer = new SceneRendererForward(_scene);

            //Transforms
            _mainPart = getTransform("Armor");
            //Tires
            _frontRightTire = getTransform("RightWheel");
            _frontLeftTire = getTransform("LeftWheel");
            _backTires = getTransform("BackWheels");

            //Turret-Parts
            TurretBase = getTransform("Turret");
            TurretBarrel = getTransform("TurretBarrel");

            //Scenepicker
            _scenePicker = new ScenePicker(_scene);

        }
        //Returns scene for Helper class
        public SceneContainer getScenConteiner()
        {
            return _scene;
        }


        public override async Task InitAsync()
        {
            await base.InitAsync();
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            SetProjectionAndViewport();

            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            // Setup the camera 
            RC.View = float4x4.CreateTranslation(0, 0, 20) * float4x4.CreateRotationX(-(float)Math.Atan(15.0 / 40.0));

            // Render the scene on the current render context
            _sceneRenderer.Render(RC);

            // Humvee Controls
            accelerateForwardBackward(3);
            turnLeftRight(1);
            nodePicker();
            Turret(1.5f);
            Present();
        }

        public void SetProjectionAndViewport()
        {
            // Set the rendering area to the entire window size
            RC.Viewport(0, 0, Width, Height);

            // Create a new projection matrix generating undistorted images on the new aspect ratio.
            var aspectRatio = Width / (float)Height;

            // 0.25*PI Rad -> 45° Opening angle along the vertical direction. Horizontal opening angle is calculated based on the aspect ratio
            // Front clipping happens at 1 (Objects nearer than 1 world unit get clipped)
            // Back clipping happens at 2000 (Anything further away from the camera than 2000 world units gets clipped, polygons will be cut)
            var projection = float4x4.CreatePerspectiveFieldOfView(M.PiOver4, aspectRatio, 1, 20000);
            RC.Projection = projection;
        }
        

        //Funktioniert nur so mäßig
        private void nodePicker()
        {
             if (Mouse.LeftButton)
            {
                float2 pickPosClip = Mouse.Position * new float2(2.0f / Width, -2.0f / Height) + new float2(-1, 1);

                PickResult newPick = _scenePicker.Pick(RC, pickPosClip).OrderBy(pr => pr.ClipPos.z).FirstOrDefault();

                if (newPick?.Node != _currentPick?.Node)
                {
                    if (_currentPick != null)
                    {
                        var ef = _currentPick.Node.GetComponent<SurfaceEffect>();
                        ef.SurfaceInput.Albedo = _oldColor;
                    }
                    if (newPick != null)
                    {
                        var ef = newPick.Node.GetComponent<SurfaceEffect>();
                        _oldColor = ef.SurfaceInput.Albedo;
                        ef.SurfaceInput.Albedo = (float4) ColorUint.OrangeRed;
                    }
                    _currentPick = newPick;
                }
            }
        }


        // Animation
        private void accelerateForwardBackward(float speed)
        {
            if (Keyboard.GetKey(KeyCodes.W))
            {
                float time = -M.MinAngle(TimeSinceStart);
                _frontRightTire.Rotation = new float3((time * speed), 0, 0);
                _frontLeftTire.Rotation = new float3((time * speed), 0, 0);
                _backTires.Rotation = new float3((time * speed), 0, 0);
            }
            else if (Keyboard.GetKey(KeyCodes.S))
            {
                float time = M.MinAngle(TimeSinceStart);
                _frontRightTire.Rotation = new float3((time * speed), 0, 0);
                _frontLeftTire.Rotation = new float3((time * speed), 0, 0);
                _backTires.Rotation = new float3((time * speed), 0, 0);
            }

        }

        private void turnLeftRight(float speed)
        {
            speed = speed / 100;
            if (Keyboard.GetKey(KeyCodes.D) && (_frontRightTire.Rotation.y <= M.Pi / 6))
            {
                _frontRightTire.Rotation = new float3(0, ((speed + _frontRightTire.Rotation.y) % M.TwoPi), 0);
                _frontLeftTire.Rotation = new float3(0, ((speed + _frontLeftTire.Rotation.y) % M.TwoPi), 0);
            }
            else if (Keyboard.GetKey(KeyCodes.A) && (_frontRightTire.Rotation.y >= (M.Pi * -1) / 6))
            {
                _frontRightTire.Rotation = new float3(0, ((-speed + _frontRightTire.Rotation.y) % M.TwoPi), 0);
                _frontLeftTire.Rotation = new float3(0, ((-speed + _frontLeftTire.Rotation.y) % M.TwoPi), 0);
            }
        }

        private void Turret(float speed)
        {
            speed = speed / 100;
            if (Keyboard.GetKey(KeyCodes.Left))
            {
                TurretBase.Rotation = new float3(0, ((-speed + TurretBase.Rotation.y) % M.TwoPi), 0);
            }
            else if (Keyboard.GetKey(KeyCodes.Right))
            {
                TurretBase.Rotation = new float3(0, ((speed + TurretBase.Rotation.y) % M.TwoPi), 0);
            }


            if (Keyboard.GetKey(KeyCodes.Up) && TurretBarrel.Rotation.x <= M.DegreesToRadians(30))
            {
                TurretBarrel.Rotation = new float3(((speed + TurretBarrel.Rotation.x) % M.TwoPi), 0, 0);
            }

            else if (Keyboard.GetKey(KeyCodes.Down) && TurretBarrel.Rotation.x >= M.DegreesToRadians(-30))
            {
                TurretBarrel.Rotation = new float3(((-speed + TurretBarrel.Rotation.x) % M.TwoPi), 0, 0);
            }
        }
    }
}