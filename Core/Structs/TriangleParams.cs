using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Engine.Core.Structs
{
    public struct TriangleParams
    {

        public Vector2 p1;
        public Vector2 p2;
        public Vector2 p3;

        public TriangleParams(Vector2 pt1, Vector2 pt2, Vector2 pt3)
        {
            p1 = pt1;
            p2 = pt2;
            p3 = pt3;
        }
    }
}
