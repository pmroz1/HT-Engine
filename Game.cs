using HT_Engine.GameObjects;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Engine
{
    public struct Game
    {
        public GameWindow game;
        public List<GameObject> objects;

        public Game(string gameTitle)
        {
            game = new GameWindow();
            game.Title = gameTitle;
            objects = new List<GameObject>();
            game.Load += Load;
            game.Resize += Resize;
            game.RenderFrame += Render;
        }

        public void Load(object sender, EventArgs e)
        {
            game.VSync = VSyncMode.On;
        }

        public void Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, game.Width, game.Height);
        }

        public void Render(object sender, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);

            foreach (GameObject obj in objects)
            {
                obj.RenderObject();
            }
        }

        public void Run()
        {
            //makes game run at 60 fps
            game.Run(60.0);
        }
    }
}
