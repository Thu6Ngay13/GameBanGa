using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBanGa
{
    public class Chicken : ObjectGame
    {
        private int chickenFrameTh = 0;
        public Chicken(int width, int heigh, Bitmap image) 
            : base(width, heigh, image)
        {
        }
    }
}
