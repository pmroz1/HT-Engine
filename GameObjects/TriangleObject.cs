using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using HT_Engine.Core.Structs;
using OpenTK;

namespace HT_Engine.GameObjects
{
    public struct TriangleObject : IGameObject
    {
        public TriangleParams tp;

        public void Move(Vector2 vec)
        {
            tp.p1 += vec;
            tp.p2 += vec;
            tp.p3 += vec;
        }

        public Color color;
        public TriangleObject(Color clr, TriangleParams tp)
        {
            this.tp = tp;
            color = clr;
        }

        public void UpdateObject()
        {
            throw new NotImplementedException();
        }

        void IGameObject.RenderObject()
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex2(tp.p1);
            GL.Vertex2(tp.p2);
            GL.Vertex2(tp.p3);
            GL.End();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}

