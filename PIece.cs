using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBanGa
{
    public class Piece : PictureBox
    {
        public Piece(int width, int height)
        {
            Width = width;
            Height = height;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;
        }
    }
}
