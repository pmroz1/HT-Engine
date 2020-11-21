using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Engine.GameObjects
{
    public interface IGameObject
    {
        void RenderObject();
        void UpdateObject();
    }
}
