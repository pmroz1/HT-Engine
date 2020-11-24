using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Engine.Animations
{
    public class AnimationSet
    {
        public int animationLength;
        public Animation2D frontView;
        public Animation2D leftSideView;
        public Animation2D rightSideView;
        public Animation2D backView;
        public List<Animation2D> skillsAnimations;

        public AnimationSet(
                int length,
                Animation2D fv,
                Animation2D lsv,
                Animation2D rsv,
                Animation2D bv
            )
        {
            animationLength = length;
            frontView = fv;
            leftSideView = lsv;
            rightSideView = rsv;
            backView = bv;
            skillsAnimations = null;
        }

        public void AddSkillAnimation(Animation2D skillFrames)
        {
            //todo
            //check legth compatibility
            skillsAnimations.Add(skillFrames);
        }

        // todo 
        // check if all animation lengths are compatible
        // eg. public void CheckCompatybility
    }
}
