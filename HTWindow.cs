using HT_Engine.Core;
using HT_Engine.GameObjects;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HT_Engine
{
    public class HTWindow
    {
        public readonly GameWindow gameWin;
        public Color BackgroundColor;
        public List<IScene> scenes;
        public int CurrentScene;

        ///<summary>
        ///Public constructor, generates game window
        /// </summary>
        public HTWindow(string gameTitle, int width, int height)
        {
            scenes = new List<IScene>();
            gameWin = new GameWindow(width, height)
            {
                Title = gameTitle
            };
            gameWin.Load += Load;
            gameWin.RenderFrame += Render;
            gameWin.UpdateFrame += Update;
        }

        ///<summary>
        ///Public constructor generate game core functonality like GameWindow
        /// <paramref name="gm"/> 
        /// </summary>
        public HTWindow(string gameTitle, int width, int height, GraphicsMode gm)
        {
            scenes = new List<IScene>();
            gameWin = new GameWindow(width, height, gm)
            {
                Title = gameTitle
            };
            gameWin.Load += Load;
            gameWin.RenderFrame += Render;
            gameWin.UpdateFrame += Update;
        }

        public HTWindow(string gameTitle, int width, int height, GraphicsMode gm, GameWindowFlags windowFlags)
        {
            scenes = new List<IScene>();
            gameWin = new GameWindow(width, height, gm, gameTitle, windowFlags);
            gameWin.Load += Load;
            gameWin.RenderFrame += Render;
            gameWin.UpdateFrame += Update;
        }

        public void Load(object sender, EventArgs e)
        {
            gameWin.VSync = VSyncMode.On;
        }

        public void Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, gameWin.Width, gameWin.Height);
        }

        /// <summary>
        /// Runs game at maximum of 60 frames pre second
        /// </summary>
        /// <param name="HTGameWindow"> target HTWindow </param>
        public void Run()
        {
            //makes game run at 60 fps
            gameWin.Run(60.0);
        }

        /// <summary>
        ///  Runs window at given maximum rate of Updates Per Second and Frames Per Second
        /// </summary>
        /// <param name="HTGameWindow">Target HTWindow</param>
        /// <param name="UPS">Updates Per Second</param>
        /// <param name="FPS">Frames Per Second</param>
        public void Run(int UPS, int FPS)
        {
            gameWin.Run(UPS, FPS);
        }

        public void Render(object sender, EventArgs e)
        {
            ClearBackground();
            Console.WriteLine("Clearing Background");
            foreach (IGameObject obj in scenes[CurrentScene].GameObjects)
            {
                obj.RenderObject();
                Console.WriteLine("RenderingObject");
            }
            //without swapping we will have 2-3fps
            gameWin.SwapBuffers();
        }

        public void Update(object sender, EventArgs e)
        {
            //foreach (IGameObject obj in scenes[CurrentScene].GameObjects)
            //{
            //    obj.UpdateObject();
            //}
        }

        private void ClearBackground()
        {
            //clears all color pixels
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(BackgroundColor);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        public void SetCurrentScene(int n)
        {
            CurrentScene = n;
        }

        public void AddScene(IScene scene)
        {
            scenes.Add(scene);
        }
    }
}
