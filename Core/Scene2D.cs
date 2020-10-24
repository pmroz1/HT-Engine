using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;
using HT_Engine.GameObjects;
using System.Drawing;

namespace HT_Engine.Core
{
    public class Scene2D : IScene
    {

        public List<IGameObject> GameObjects { get; set; }
        //add background colors
        public Scene2D()
        {
            this.GameObjects = new List<IGameObject>();
        }

        public void RenderScene()
        {
            foreach (IGameObject obj in GameObjects)
            {
                obj.RenderObject();
            }
        }

        public void UpdateScene()
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                IGameObject obj = GameObjects[i];
                obj.UpdateObject();
            }
        }

        public void AddObject(IGameObject obj)
        {
            GameObjects.Add(obj);
        }
    }
}
