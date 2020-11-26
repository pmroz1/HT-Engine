using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Engine.Animations
{
    public class Animation2D : IAnimation
    {
        public string name;
        public int animationLength;
        /// <summary>
        /// Points to root location of all animation frames. Frames should be named " 1.desired_extension " e.g: 1.jpg, 2.jpg, 
        /// etc
        /// </summary>
        public string pathToFramesRoot;

        public Animation2D(string name)
        {
            this.name = name;
        }

        public Animation2D(string name, int animationlength)
        {
            this.name = name;
            animationLength = animationlength;
        }

        public Animation2D(string name, int animationlength, string framesLocation)
        {
            this.name = name;
            pathToFramesRoot = framesLocation;
            animationLength = animationlength;
            if (name != null && pathToFramesRoot != null && animationLength != 0)
            {
                LoadFrames();
            }
        }

        public void ForceCheck()
        {
            if (name != null && pathToFramesRoot != null && animationLength != 0)
            {
                LoadFrames();
            }
        }

        public void LoadFrames()
        {
            int i = 0;
            while (i <= animationLength)
            {
                //chesk if viable frames
                if (true)
                {
                    throw new Exception("Error loading frames");
                }
            }
        }
    }
}
