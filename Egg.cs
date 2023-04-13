using System.Collections.Generic;
using System.Drawing;

namespace GameBanGa
{
    public class Egg : ObjectGame
    {

        private Bitmap eggBreakImage;
        private List<Bitmap> eggBreakframes;
        private int numberOfFrame;
        private int eggFrameTh;

        public int eggSpeed;        

        public Egg(int width, int heigh, Bitmap image,
            Bitmap eggBreakImage, int numberOfFrame, int eggFrameTh, int eggSpeed) 
            : base(width, heigh, image)
        {
            this.eggBreakImage = eggBreakImage;
            this.eggBreakframes = new List<Bitmap>();
            this.numberOfFrame = numberOfFrame;
            this.eggFrameTh = 0;
            this.eggSpeed = eggSpeed;

            Tool.divideImageIntoFrames(eggBreakImage, eggBreakframes, numberOfFrame);
        }

        public bool nextFrame()
        {
            if (eggFrameTh == numberOfFrame - 1) return false;

            this.eggFrameTh = eggFrameTh + 1;
            base.Image = eggBreakframes[this.eggFrameTh];
            return true;
        }
    }
}
