using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBanGa
{
    public class Tool
    {
        public static void divideImageIntoFrames(Bitmap image, List<Bitmap> frames, int n)
        {
            int w = image.Width / n;
            int h = image.Height;
            for (int i = 0; i < n; ++i)
            {
                Bitmap frame = new Bitmap(w, h);
                for (int y = 0; y < h; ++y)
                    for (int x = 0; x < w; ++x)
                        frame.SetPixel(x, y, image.GetPixel(x + i * w, y));

                frames.Add(frame);
            }
        }
    }
}
