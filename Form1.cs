using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameBanGa
{
    public partial class Form1 : Form
    {
        //Tao may bay
        private Piece rocket;

        //Tao dan ban ra
        private List<Piece> bullets = new List<Piece>();

        //Tao chua hinh anh cua ga
        private Bitmap chichkenImage = Properties.Resources.chickenRed;

        //Tao 1 list khung hinh cho ga
        private List<Bitmap> chickenFrames = new List<Bitmap>();
        
        //Tao mang 2 chieu ga
        //3 hang
        //8 cot
        private Piece[,] checkens = new Piece[3, 8];

        //1 mang de biet rang con ga nao dung truoc
        int[] topChecken = new int[3];

        public Form1()
        {
            InitializeComponent();
            initial();
        }

        private void initial()
        {
            rocket = new Piece(50, 50);
            rocket.Left = this.Width / 2 - rocket.Width / 2;
            rocket.Top = this.Height - rocket.Height;
            rocket.Image = Properties.Resources.ship;
            this.Controls.Add(rocket);

            divideImageIntoFrames(chichkenImage, chickenFrames, 10);
            createChickens();
        }

        private void tm_Bullets_Tick(object sender, EventArgs e)
        {
            foreach(Piece bullet in bullets)
                bullet.Top -= 10;
        }

        private void tm_Chickens_Tick(object sender, EventArgs e)
        {

        }

        private void tm_Eggs_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    rocket.Left -= 10;
                    break;
                case Keys.Right:
                    rocket.Left += 10;
                    break;
                case Keys.Down:
                    rocket.Top += 10;
                    break;
                case Keys.Up:
                    rocket.Top -= 10;
                    break;
            }
                
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                launchBullet();
        }


        private void divideImageIntoFrames(Bitmap orignal, List<Bitmap> res, int n)
        {
            //cat hinh anh cua checkenRed thanh 1 hinh, tai co 10 con ga trong nay
            int w = orignal.Width / n;
            int h = orignal.Height;
            for(int i = 0; i < n; ++i)
            {
                int s = i * w;
                Bitmap piece = new Bitmap(w, h);
                for (int j = 0; j < h; j++)
                    for (int k = 0; k < w; k++)
                        piece.SetPixel(k, j, orignal.GetPixel(k + s, j));
                res.Add(piece);
            }
        }
        private void createChickens()
        {
            Bitmap img = chickenFrames[0];
            for(int i = 0; i < 3; ++i)
            {
                topChecken[i] = i * 30 + img.Height;
                for(int j = 0; j < 8; ++j)
                {
                    Piece chicken = new Piece(30, 30);
                    chicken.Image = img;
                    chicken.Left = j * 30;
                    chicken.Top = i * 30 + img.Height;
                    checkens[i, j] = chicken;
                    this.Controls.Add(chicken);
                }
            }
        }
        private void launchBullet()
        {
            Piece bullet = new Piece(10, 10);
            bullet.Left = rocket.Left + rocket.Width / 2 - bullet.Width / 2;
            bullet.Top = rocket.Top - bullet.Height;
            bullet.Image = Properties.Resources.b2;

            bullets.Add(bullet);
            this.Controls.Add(bullet);
        }
    }
}
