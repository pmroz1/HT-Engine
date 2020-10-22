using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Engine
{
    public struct Game
    {
        public GameWindow game;

        public Game(string gameTitle)
        {
            game = new GameWindow();
            game.Title = gameTitle;
        }

        public void Run()
        {
            //makes game run at 60 fps
            game.Run(60.0);
        }
    }
}
