using System.Drawing;

namespace GameBanGa
{
    public class Bullet : ObjectGame
    {
        public int bulletSpeed;

        public Bullet(int width, int heigh, Bitmap image,
            int bulletSpeed)
            : base(width, heigh, image)
        {
            this.bulletSpeed = bulletSpeed;
        }
    }
}
