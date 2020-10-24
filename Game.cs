using HT_Engine.GameObjects;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HT_Engine
{
    public struct Game
    {
        public GameWindow game;
        public Color BackgroundColor;
        public List<IGameObject> objects;

        //public Game(string gameTitle)
        //{
        //    game = new GameWindow();
        //    game.Title = gameTitle;
        //    objects = new List<IGameObject>();
        //    game.Load += Load;
        //    game.Resize += Resize;
        //    game.RenderFrame += Render;
        //}

        public Game(string gameTitle, Color BkgColor)
        {
            game = new GameWindow();
            game.Title = gameTitle;
            objects = new List<IGameObject>();
            BackgroundColor = BkgColor;
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
            GL.ClearColor(BackgroundColor);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);

            foreach (IGameObject obj in objects)
            {
                obj.RenderObject();
            }
            //without swapping we will have 2-3fps
            game.SwapBuffers();
        }

        public void Run(GameWindow gameWindow)
        {
            //makes game run at 60 fps
            gameWindow.Run(60.0);
        }

        public void AddObject(IGameObject obj)
        {
            objects.Add(obj);
        }
    }
}
