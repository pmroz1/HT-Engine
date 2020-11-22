using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Engine.GameObjects.Actors
{
    public interface IActor
    {
        void RenderObject();
        void UpdateObject();
        void Move(Vector2 vec);

        void LoadActorTexture(string path);
        bool CheckIfIsPlayer();
    }
}
