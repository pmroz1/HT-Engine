using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace HT_Engine.GameObjects
{
    public struct TriangleObject : IGameObject
    {
        public Color color;
        public TriangleObject(Color clr)
        {
            color = clr;
        }

        public void UpdateObject()
        {
            throw new NotImplementedException();
        }

        void IGameObject.RenderObject()
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex2(-1.0f, -1.0f);
            GL.Vertex2(0.0f, 1.0f);
            GL.Vertex2(1.0f, -1.0f);
            GL.End();
        }
    }
}

