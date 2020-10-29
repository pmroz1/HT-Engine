using HT_Engine.Animations;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Engine.GameObjects.Actors
{
    public class Actor2D : IActor
    {
        public string actorName;
        public Vector2 actorPosition;
        public AnimationSet animations;

        public Actor2D(Vector2 position, string name)
        {
            actorPosition = position;
            actorName = name;
        }

        public Actor2D(Vector2 position, string name, AnimationSet animation)
        {
            actorPosition = position;
            actorName = name;
            this.animations = animation;
        }

        public void RenderObject()
        {
            throw new NotImplementedException();
        }

        public void UpdateObject()
        {
            throw new NotImplementedException();
        }
    }
}
