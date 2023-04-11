using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GameBanGa
{
    public class ObjectGame : PictureBox
    {
        protected Bitmap image;

        public ObjectGame(int width, int heigh, Bitmap image)
        {
            this.Width = width;
            this.Height = heigh;
            this.image = image;

            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;
        }
    }
}
