using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Engine.Core.Structs
{
    public struct ActorCoords
    {
        public Vector2[] pts;

        public ActorCoords(Vector2[] coords)
        {
            pts = new Vector2[coords.Length];
            for (int i = 0; i < coords.Length; ++i)
            {
                pts[i] = coords[i];
            }
        }
    }
}
