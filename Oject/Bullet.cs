using System.Collections.Generic;
using System.Drawing;

namespace GameBanGa
{
    public class Bullet : ObjectGame
    {
        public static List<Bitmap> Bullets = new List<Bitmap>()
        {
            Properties.Resources.a1,
            Properties.Resources.a2,
            Properties.Resources.a3,
            Properties.Resources.b1,
            Properties.Resources.b2,
            Properties.Resources.b3
        };

        public int bulletSpeed;

        public Bullet(int width, int heigh, Bitmap image,
            int bulletSpeed)
            : base(width, heigh, image)
        {
            this.bulletSpeed = bulletSpeed;
        }
    }
}
