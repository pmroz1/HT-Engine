using HT_Engine.Animations;
using HT_Engine.Core.Structs;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using OpenTK.Graphics.OpenGL;
using HT_Engine.Graphics;

namespace HT_Engine.GameObjects.Actors
{
    public class Actor2D : IActor
    {
        public string actorName;
        public Vector2 actorPosition;
        public AnimationSet animations;
        public ActorCoords coords;
        public Color color;

        public int texture;

        public Actor2D(ActorCoords pos, Color clr)
        {
            coords = pos;
            color = clr;
            texture = -1;
        }

        public Actor2D(Vector2 position, string name)
        {
            actorPosition = position;
            actorName = name;
            texture = -1;
        }

        public Actor2D(Vector2 position, string name, AnimationSet animation)
        {
            actorPosition = position;
            actorName = name;
            animations = animation;
            texture = -1;
        }
        public Actor2D(Vector2 position, string name, AnimationSet animation, ActorCoords ac)
        {
            coords = ac;
            actorPosition = position;
            actorName = name;
            this.animations = animation;
            texture = -1;
        }

        public void LoadActorTexture(string path)
        {
            texture = ContentPipe.LoadTexture(path);
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
            if (texture != -1)
            {
                GL.BindTexture(TextureTarget.Texture2D, texture);
                GL.Begin(PrimitiveType.Quads);

                int i = 0;
                foreach (Vector2 x in coords.pts)
                {
                    switch (i)
                    {
                        case 0:
                            GL.TexCoord2(0, 0);
                            break;
                        case 1:
                            GL.TexCoord2(1, 0);
                            break;
                        case 2:
                            GL.TexCoord2(1, 1);
                            break;
                        case 3:
                            GL.TexCoord2(0, 1);
                            break;
                    }
                    GL.Vertex2(x);
                    ++i;
                }
                GL.End();
            }
            else
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(Color.Aqua);
                foreach (Vector2 x in coords.pts)
                {
                    if (color != null)
                    {
                        GL.Color3(color);
                    }
                    GL.Vertex2(x);
                }
                GL.End();
            }
        }

        public void UpdateObject()
        {
            throw new NotImplementedException();
        }
    }
}
