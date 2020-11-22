using HT_Engine.Animations;
using HT_Engine.Core.Structs;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace HT_Engine.GameObjects.Actors
{
    public class Actor2D : IActor
    {
        public string actorName;
        public Vector2 actorPosition;
        public AnimationSet animations;
        public ActorCoords coords;
        public Color color;

        public Actor2D(ActorCoords pos, Color clr)
        {
            coords = pos;
            color = clr;
        }

        public Actor2D(Vector2 position, string name)
        {
            actorPosition = position;
            actorName = name;
        }

        public Actor2D(Vector2 position, string name, AnimationSet animation)
        {
            actorPosition = position;
            actorName = name;
            animations = animation;
        }
        public Actor2D(Vector2 position, string name, AnimationSet animation, ActorCoords ac)
        {
            coords = ac;
            actorPosition = position;
            actorName = name;
            this.animations = animation;
        }

        public void Move(Vector2 vec)
        {
            for (int i = 0; i < coords.pts.Length; ++i)
            {
                coords.pts[i] += vec;
            }

            //foreach (Vector2 x in coords.pts)
            //{
            //    x[1] += vec;
            //}
        }

        public void RenderObject()
        {
            GL.Begin(PrimitiveType.Quads);
            foreach (Vector2 x in coords.pts)
            {
                GL.Vertex2(x);
            }
            GL.End();
        }

        public void UpdateObject()
        {
            throw new NotImplementedException();
        }
    }
}
