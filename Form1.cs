using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace GameBanGa
{
    public partial class Form1 : Form
    {
        private int live = 3;
        //Danh sach so mang song
        private List<Piece> hearts = new List<Piece>();

        //Tao may bay
        private Piece rocket;
        //Tao dan ban ra
        private List<Piece> bullets = new List<Piece>();

        //Tao chua hinh anh cua ga
        private Bitmap chichkenImage = Properties.Resources.chickenRed;
        //Tao 1 list khung hinh cho ga
        private List<Bitmap> chickenFrames = new List<Bitmap>();
        //Tao mang 2 chieu ga: 3 hang, 8 cot
        private Piece[,] chickens = new Piece[3, 8];
        //1 mang int de biet rang con ga nao dung truoc
        int[] topChecken = new int[3];
        //tao toc do cua con  ga
        private int chickenSpeed = 1;
        private int leftMostChicken = 0;
        private int count = 0;
        private int dt = 1;

        private Bitmap eggBreakImage = Properties.Resources.eggWhiteBreak;
        private List<Bitmap> eggBreakFrames = new List<Bitmap>();
        private List<Piece> eggs = new List<Piece>();

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
            createHeart();

            divideImageIntoFrames(eggBreakImage, eggBreakFrames, 8);
            
        }

        private void tm_Bullets_Tick(object sender, EventArgs e)
        {
            foreach(Piece bullet in bullets)
                bullet.Top -= 10;
        }

        private void tm_Chickens_Tick(object sender, EventArgs e)
        {
            if (leftMostChicken + 270 > this.Width || leftMostChicken < 0)
                chickenSpeed = -chickenSpeed;
            leftMostChicken += chickenSpeed;
            for (int i = 0; i < 3; ++i)
                for(int j = 0; j < 8; j++)
                {
                    if (chickens[i, j] == null) continue;
                    chickens[i, j].Image = chickenFrames[count];
                    chickens[i, j].Left += chickenSpeed;
                }
            count += dt;
            count %= 10;
        }

        private void tm_Eggs_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (rand.Next(200) == 5) launchRandomEgg();
            if (eggs.Count == 0) return;
            foreach(Piece egg in eggs)
            {
                egg.Top += egg.eggSpeed;
                if (rocket.Bounds.IntersectsWith(egg.Bounds))
                {
                    this.Controls.Remove(egg);
                    eggs.Remove(egg);
                    decreaseHeart();
                    break;
                }
                if(egg.Top >= 300 - (egg.Height + 20))
                {
                    egg.eggSpeed = 0;
                    if(egg.eggLandCount/10 < eggBreakFrames.Count)
                    {
                        egg.Image = eggBreakFrames[egg.eggLandCount/10 % 8];
                        egg.eggLandCount++;
                    }
                    else
                    {
                        this.Controls.Remove(egg);
                        eggs.Remove(egg);
                    }
                }
            }
        }

        private void decreaseHeart()
        {
            live--;
            hearts[live].Image = Properties.Resources.heartDead;
            if (live < 1) endGame();
            
        }

        private void endGame()
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
                    chicken.Left = j * 30; //30*8 + (width = 30) = 270
                    chicken.Top = i * 30 + img.Height;
                    chickens[i, j] = chicken;
                    this.Controls.Add(chicken);
                }
            }
        }

        

        private void createHeart()
        {
            Bitmap heart = Properties.Resources.heartLive;
            for(int i = 0; i < 3; ++i)
            {
                hearts.Add(new Piece(50, 50));
                hearts[i].Image = heart;
                hearts[i].Left = this.Width - (3 - i) * 45;
                this.Controls.Add(hearts[i]);
            }
                
        }

        private void launchRandomEgg()
        {
            List<Piece> availableChickens = new List<Piece>();
            for(int i = 0; i < 3; ++i)
                for(int j = 0; j < 8; ++j)
                {
                    if (chickens[i, j] == null) continue;
                    availableChickens.Add(chickens[i, j]);
                }

            Random rand = new Random();
            Piece chicken = availableChickens[rand.Next() % availableChickens.Count];
            Piece egg = new Piece(20, 20);
            egg.Image = Properties.Resources.eggWhite;
            egg.Left = chicken.Left + chicken.Width / 2 - egg.Width / 2;
            egg.Top = chicken.Top + chicken.Height;
            eggs.Add(egg);
            this.Controls.Add(egg);
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
