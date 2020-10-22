using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace HT_Engine.GameObjects
{
    public struct RectangleObject : IGameObject
    {
        public Color color;
        public RectangleObject(Color clr)
        {
            color = clr;
        }

        void IGameObject.RenderObject()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(color);
            GL.TexCoord2(0, 1); GL.Vertex2(0, 32);
            GL.TexCoord2(1, 1); GL.Vertex2(32, 32);
            GL.TexCoord2(1, 0); GL.Vertex2(32, 0);
            GL.TexCoord2(0, 0); GL.Vertex2(0, 0);
            GL.End();
        }
    }
}
