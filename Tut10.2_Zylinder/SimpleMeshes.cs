using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusee.Engine.Core;
using Fusee.Engine.Core.Scene;
using Fusee.Engine.Core.Effects;
using Fusee.Math.Core;
using Fusee.Serialization;


namespace FuseeApp
{
    public static class SimpleMeshes
    {
        public static Mesh CreateCuboid(float3 size)
        {
            return new Mesh
            {
                Vertices = new[]
                {
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z}
                },

                Triangles = new ushort[]
                {
                    // front face
                    0, 2, 1, 0, 3, 2,

                    // right face
                    4, 6, 5, 4, 7, 6,

                    // back face
                    8, 10, 9, 8, 11, 10,

                    // left face
                    12, 14, 13, 12, 15, 14,

                    // top face
                    16, 18, 17, 16, 19, 18,

                    // bottom face
                    20, 22, 21, 20, 23, 22

                },

                Normals = new[]
                {
                    new float3(0, 0, 1),
                    new float3(0, 0, 1),
                    new float3(0, 0, 1),
                    new float3(0, 0, 1),
                    new float3(1, 0, 0),
                    new float3(1, 0, 0),
                    new float3(1, 0, 0),
                    new float3(1, 0, 0),
                    new float3(0, 0, -1),
                    new float3(0, 0, -1),
                    new float3(0, 0, -1),
                    new float3(0, 0, -1),
                    new float3(-1, 0, 0),
                    new float3(-1, 0, 0),
                    new float3(-1, 0, 0),
                    new float3(-1, 0, 0),
                    new float3(0, 1, 0),
                    new float3(0, 1, 0),
                    new float3(0, 1, 0),
                    new float3(0, 1, 0),
                    new float3(0, -1, 0),
                    new float3(0, -1, 0),
                    new float3(0, -1, 0),
                    new float3(0, -1, 0)
                },

                UVs = new[]
                {
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0),
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0),
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0),
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0),
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0),
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0)
                },
                BoundingBox = new AABBf(-0.5f * size, 0.5f * size)
            };
        }

        public static SurfaceEffect MakeMaterial(float4 color)
        {
            return MakeEffect.FromDiffuseSpecular(
                albedoColor: color,
                emissionColor: float3.Zero,
                shininess: 25.0f,
                specularStrength: 1f);
        }

        public static Mesh CreateCylinder(float radius, float height, int segments)
        {
            //parameters
            float aHight = height / 2;
            float bHight = -height / 2;
            float delta = 2 * M.Pi / segments;

            //index for verts and norms
            int v = 0; 
            int n = 0;


            //array for Top- and Bootom-Parts
            float3[] verts = new float3[((segments + 1) * 2) + ((segments) * 2)];
            float3[] norms = new float3[((segments + 1) * 2) + ((segments) * 2)];
            ushort[] tris = new ushort[((segments * 3) * 2) + ((segments * 3) * 2)];


            //bottom (aHight)
            for (int i = 0; i < (segments); i++)
            {
                verts[v] = new float3(radius * M.Cos(i * delta), aHight, radius * M.Sin(i * delta));
                norms[v] = new float3(0, 1, 0);

                tris[(n) * 3 + 0] = (ushort)(n);
                if (i < segments - 1)
                {
                    tris[(n) * 3 + 2] = (ushort)segments;
                    tris[(n) * 3 + 1] = (ushort)(n + 1);
                }
                else
                {
                    tris[(n) * 3 + 1] = (ushort)(0);
                    tris[(n) * 3 + 2] = (ushort)(n + 1);
                }
                n++;
                v++;
            }
            verts[v] = new float3(0, aHight, 0);
            norms[v] = new float3(0, 1, 0);
            v++;


            //bottom (bHight)
            for (int i = 0; i < (segments); i++)
            {
                verts[v] = new float3(radius * M.Cos(i * delta), bHight, radius * M.Sin(i * delta));
                norms[v] = new float3(0, 1, 0);
                tris[(n) * 3 + 0] = (ushort)(v);

                if (i < segments - 1)
                {
                    tris[(n) * 3 + 1] = (ushort)(segments * 2 + 1);
                    tris[(n) * 3 + 2] = (ushort)(v + 1);
                }
                else
                {                  
                    tris[(n) * 3 + 2] = (ushort)(segments + 1);
                    tris[(n) * 3 + 1] = (ushort)(v + 1);
                }
                n++;
                v++;
            }
            verts[v] = new float3(0, bHight, 0);
            norms[v] = new float3(0, -1, 0);
            v++;

            for (int i = 0; i < (segments); i++)
            {

                verts[v] = new float3(radius * M.Cos(i * delta), aHight, radius * M.Sin(i * delta));
                norms[v] = new float3(M.Cos(i * delta), 0, M.Sin(i * delta));

                verts[v + segments] = new float3(radius * M.Cos(i * delta), bHight, radius * M.Sin(i * delta));
                norms[v + segments] = new float3(M.Cos(i * delta), 0, M.Sin(i * delta));

                if (i < (segments - 1))
                {
                    //halfwaypoint of coating
                    tris[n * 3 + 0] = (ushort)(v);
                    tris[n * 3 + 2] = (ushort)(v + 1);
                    tris[n * 3 + 1] = (ushort)(v + segments);
                    
                    tris[(n + segments) * 3 + 0] = (ushort)(v + 1);
                    tris[(n + segments) * 3 + 1] = (ushort)(v + segments);
                    tris[(n + segments) * 3 + 2] = (ushort)(v + segments + 1);
                }
                else
                {
                    tris[n * 3 + 0] = (ushort)(v);
                    tris[n * 3 + 2] = (ushort)(v + 1);
                    tris[n * 3 + 1] = (ushort)(v + segments);
                    
                    tris[3*segments - 1] = (ushort) segments; // center point
                    tris[3*segments - 2] = (ushort) 0;        // current segment point
                    tris[3*segments - 3] = (ushort) (segments-1);    // previous segment point  

                    //Bekomme hier das letzte Dreieck des Mantels nicht geschlossen. Ober- und Unterdeckel des Zylinders sind jedoch vollständig                  
                }
                v++;
                n++;
            }

            return new Mesh

            {
                Vertices = verts,
                Normals = norms,
                Triangles = tris,
            };
        }

        public static Mesh CreateCone(float radius, float height, int segments)
        {
            return CreateConeFrustum(radius, 0.0f, height, segments);
        }

        public static Mesh CreateConeFrustum(float radiuslower, float radiusupper, float height, int segments)
        {
            throw new NotImplementedException();
        }

        public static Mesh CreatePyramid(float baselen, float height)
        {
            throw new NotImplementedException();
        }
        public static Mesh CreateTetrahedron(float edgelen)
        {
            throw new NotImplementedException();
        }

        public static Mesh CreateTorus(float mainradius, float segradius, int segments, int slices)
        {
            throw new NotImplementedException();
        }

    }
}