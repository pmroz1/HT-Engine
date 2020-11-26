using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;
using HT_Engine.GameObjects;
using System.Drawing;
using HT_Engine.GameObjects.Actors;

namespace HT_Engine.Core
{
    public class Scene2D : IScene
    {

        public List<IActor> GameObjects { get; set; }
        //add background colors
        public Scene2D()
        {
            this.GameObjects = new List<IActor>();
        }

        public void RenderScene()
        {
            foreach (IActor obj in GameObjects)
            {
                obj.RenderObject();
            }
        }

        public void UpdateScene()
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                IActor obj = GameObjects[i];
                obj.UpdateObject();
            }
        }

        public void AddObject(IActor obj)
        {
            GameObjects.Add(obj);
        }

        public void RemoveObj(IActor obj)
        {
            GameObjects.Remove(obj);
        }
    }
}
