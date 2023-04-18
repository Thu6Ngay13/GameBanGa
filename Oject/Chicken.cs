using System.Collections.Generic;
using System.Drawing;
using System.Media;
namespace GameBanGa
{
    public class Chicken : ObjectGame
    {
        private List<Bitmap> chickenFrames;
        private int numberOfFrame;
        private int chickenFrameTh;

        public int chickenSpeed;

        public Chicken(int width, int heigh, Bitmap chickenImage,
            int numberOfFrame, int chickenFrameTh, int chickenSpeed)
            : base(width, heigh, chickenImage)
        {
            this.chickenFrames = new List<Bitmap>();
            this.numberOfFrame = numberOfFrame;
            this.chickenFrameTh = 0;
            this.chickenSpeed = chickenSpeed;

            Tool.divideImageIntoFrames(chickenImage, chickenFrames, numberOfFrame);
            base.Image = chickenFrames[chickenFrameTh];
        }

        public bool nextFrame()
        {
            this.chickenFrameTh = (chickenFrameTh + 1) % numberOfFrame;
            base.Image = chickenFrames[this.chickenFrameTh];
            return true;
        }
    }
}
