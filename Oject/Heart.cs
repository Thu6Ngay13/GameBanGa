using System.Drawing;

namespace GameBanGa
{
    public class Heart : ObjectGame
    {
        public int heartSpeed;
        public Heart(int width, int heigh, Bitmap heartImage, int heartSpeed)
            : base(width, heigh, heartImage)
        {
            this.heartSpeed = heartSpeed;
        }

    }
}
