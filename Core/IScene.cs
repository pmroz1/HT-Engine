using HT_Engine.GameObjects;
using HT_Engine.GameObjects.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Engine.Core
{
    public interface IScene
    {
        ///List<Action> functions = new List<Action>();
        ///functions.Add(Move);
        ///functions.Add(() => MoveTo(1, 5));
        ///
        ///foreach (Action func in functions)
        ///    func();

        List<IActor> GameObjects { get; set; }

        void RenderScene();
        void UpdateScene();
    }
}



