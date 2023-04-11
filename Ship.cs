using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBanGa
{
    public class Ship : ObjectGame
    {
        public Ship(int width, int heigh, Bitmap image)
            : base(width, heigh, image)
        {
        }
    }
}
