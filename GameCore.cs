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
    public class GameCore
    {
        public readonly GameWindow HTWindow;
        public Color BackgroundColor;
        public List<IGameObject> objects;

        ///<summary>
        ///Public constructor generate game core functonality like GameWindow
        /// </summary>
        public GameCore(string gameTitle, int width, int height)
        {
            HTWindow = new GameWindow(width, height)
            {
                Title = gameTitle
            };
            objects = new List<IGameObject>();
            HTWindow.Load += Load;
            HTWindow.RenderFrame += Render;
        }

        ///<summary>
        ///Public constructor generate game core functonality like GameWindow
        /// <paramref name="gm"/> 
        /// </summary>
        public GameCore(string gameTitle, int width, int height, GraphicsMode gm)
        {
            HTWindow = new GameWindow(width, height, gm)
            {
                Title = gameTitle
            };
            objects = new List<IGameObject>();
            HTWindow.Load += Load;
            HTWindow.RenderFrame += Render;
        }

        public GameCore(string gameTitle, int width, int height, GraphicsMode gm, GameWindowFlags windowFlags)
        {
            ///<summary
            HTWindow = new GameWindow(width, height, gm, gameTitle, windowFlags);
            objects = new List<IGameObject>();
            HTWindow.Load += Load;
            HTWindow.RenderFrame += Render;
        }

        public void Load(object sender, EventArgs e)
        {
            HTWindow.VSync = VSyncMode.On;
        }

        public void Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, HTWindow.Width, HTWindow.Height);
        }

        /// <summary>
        /// Occurs when its time to render a scene
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            HTWindow.SwapBuffers();
        }

        /// <summary>
        /// Runs game at maximum of 60 frames pre second
        /// </summary>
        /// <param name="HTGameWindow"> target HTWindow </param>
        public void Run(GameWindow HTGameWindow)
        {
            //makes game run at 60 fps
            HTGameWindow.Run(60.0);
        }

        /// <summary>
        ///  Runs window at given maximum rate of Updates Per Second and Frames Per Second
        /// </summary>
        /// <param name="HTGameWindow">Target HTWindow</param>
        /// <param name="UPS">Updates Per Second</param>
        /// <param name="FPS">Frames Per Second</param>
        public void Run(GameWindow HTGameWindow, int UPS, int FPS)
        {
            //makes game run at 60 fps
            HTGameWindow.Run(UPS,FPS);
        }

        public void AddObject(IGameObject obj)
        {
            objects.Add(obj);
        }
    }
}
