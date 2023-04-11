using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameBanGa
{
    public class ObjectGame : PictureBox
    {
        public ObjectGame(int width, int heigh, Bitmap image)
        {
            Width = width;
            Height = heigh;
            Image = image;

            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;
        }
    }
}
