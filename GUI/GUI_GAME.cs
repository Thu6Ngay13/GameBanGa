using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameBanGa
{
    public partial class GUI_GAME : Form
    {
        private Ship ship;
        private Chicken[,] chickens;
        private List<Egg> eggs;
        private List<Bullet> bullets;
        private List<Heart> hearts;

        private int lives;
        private int rows;
        private int cols;
        private bool scintillate;
        private int score;
        private int level;

        public GUI_GAME()
        {
            InitializeComponent();
            initialUI_Menu();
        }

        //
        private void initialUI_Menu()
        {
            this.SuspendLayout();
            if (this.Controls.Contains(this.pnl_EndGame))
                this.Controls.Remove(this.pnl_EndGame);
            this.Controls.Add(this.pnl_Menu);
            this.ResumeLayout(false);
        }
        private void initialUI_Play()
        {
            this.SuspendLayout();
            if (this.Controls.Contains(this.pnl_Menu)) 
                    this.Controls.Remove(this.pnl_Menu);
            if (this.Controls.Contains(this.pnl_EndGame))
                this.Controls.Remove(this.pnl_EndGame);
            this.Controls.Add(this.pnl_Play);
            this.ResumeLayout(false);

            this.pnl_Play.SuspendLayout();
            this.pnl_Play.Controls.Add(this.lbl_ScorePlay);
            this.initial();
            this.pnl_Play.ResumeLayout(false);

            this.tmr_Bullets.Enabled = true;
            this.tmr_Chickens.Enabled = true;
            this.tmr_Eggs.Enabled = true;
        }
        private void initialUI_EndGame(bool isWin)
        {
            this.SuspendLayout();
            this.pnl_Play.Controls.Clear();
            this.Controls.Remove(this.pnl_Play);
            this.Controls.Add(this.pnl_EndGame);
            this.ResumeLayout(false);

            this.pnl_EndGame.SuspendLayout();
            if(isWin) this.pnl_EndGame.BackgroundImage = Properties.Resources.win;
            else this.pnl_EndGame.BackgroundImage = Properties.Resources.lose;
            this.pnl_EndGame.BackgroundImageLayout = ImageLayout.Center;
            this.lbl_ScoreEndGame.Text = "Điểm của bạn là: " + this.score.ToString();
            this.pnl_EndGame.ResumeLayout(false);

            this.tmr_Bullets.Enabled = false;
            this.tmr_Chickens.Enabled = false;
            this.tmr_Eggs.Enabled = false;
            this.tmr_Revival.Enabled = false;
            this.tmr_WaitRevival.Enabled = false;   
        }

        //Khoi tao cac doi tuong trong game
        private void initial()
        {

            initialShip();
            initialChicken(1);
            initialScore();
        }
        private void initialShip()
        {
            this.ship = new Ship(50, 50, Properties.Resources.shipLive);
            this.ship.Left = this.pnl_Play.Width / 2 - ship.Width / 2;
            this.ship.Top = this.pnl_Play.Height - ship.Height;

            this.lives = 10;
            initialHeart();

            this.bullets = new List<Bullet>();
            this.scintillate = false;

            this.pnl_Play.Controls.Add(ship);
        }
        private void initialChicken(int i)
        {
            if(i == 1) initialBaseChicken(3, 8);
            else if (i == 2) initialSuperChicken(2, 6);
        }
        private void initialBaseChicken(int rows, int cols)
        {
            this.level = 1;
            this.rows = rows;
            this.cols = cols;
            this.chickens = new Chicken[rows, cols];
            this.eggs = new List<Egg>();

            for (int x = 0; x < cols; ++x)
            {
                for (int y = rows - 1; y >= 0; --y)
                {
                    Chicken chicken = new Chicken(30, 30, Properties.Resources.chickenRed, 10, 0, 3);
                    chicken.Left = x * 50; //khoang cach theo chieu x giua cac con ga la 30
                    chicken.Top = y * 50 + chicken.Height; //khoang cach theo chieu y cua cac con la 30

                    this.chickens[y, x] = chicken;
                    this.pnl_Play.Controls.Add(chicken);
                }
            }
        }
        private void initialSuperChicken(int rows, int cols)
        {
            this.level = 2;
            this.rows = rows;
            this.cols = cols;
            this.chickens = new Chicken[rows, cols];

            for (int x = 0; x < cols; ++x)
            {
                for (int y = rows - 1; y >= 0; --y)
                {
                    Chicken chicken = new Chicken(70, 50, Properties.Resources.chickenGreen, 10, 0, 3);
                    chicken.Left = x *70 ; //khoang cach theo chieu x giua cac con ga la 30
                    chicken.Top = y * 50 + chicken.Height ; //khoang cach theo chieu y cua cac con la 30

                    this.chickens[y, x] = chicken;
                    this.pnl_Play.Controls.Add(chicken);
                }
            }
        }
        private void initialHeart()
        {
            this.hearts = new List<Heart>();
            for (int i = 0; i < this.lives; i++)
            {
                Heart heart = new Heart(30, 30, Properties.Resources.heartLive);
                heart.Left = this.pnl_Play.Width - (i + 1) * heart.Width;
                heart.Top = 0;

                this.hearts.Add(heart);
                this.pnl_Play.Controls.Add(heart);
            }

        }
        private void initialBullet()
        {
            Bullet bullet = new Bullet(5, 15, Properties.Resources.b1, 10);
            bullet.Left = this.ship.Left + this.ship.Width / 2 - bullet.Width / 2;
            bullet.Top = this.ship.Top - bullet.Height;

            this.bullets.Add(bullet);
            this.pnl_Play.Controls.Add(bullet);
        }
        private void initialEgg()
        {
            List<Chicken> availableChickens = new List<Chicken>();
            for (int x = 0; x < this.cols; ++x)
                for (int y = this.rows - 1; y >= 0; --y)
                {
                    if (chickens[y, x] == null) continue;
                    availableChickens.Add(chickens[y, x]);
                }

            if (availableChickens.Count == 0) return;

            Random rand = new Random();
            Chicken chicken = availableChickens[(rand.Next() / 1000) % availableChickens.Count];

            Egg egg = new Egg(10, 10, Properties.Resources.eggWhite, Properties.Resources.eggWhiteBreak, 8, 0, 5);
            egg.Left = chicken.Left + chicken.Width / 2 - egg.Width / 2;
            egg.Top = chicken.Top + chicken.Height;

            this.eggs.Add(egg);
            this.pnl_Play.Controls.Add(egg);
        }
        private void initialScore()
        {
            this.score = 0;
        }

        //
        private bool shipDie()
        {
            if (tmr_WaitRevival.Enabled) return false;

            changePoint(-3);
            if (!decreaseHeart()) endGame(false);

            tmr_WaitRevival.Start();
            tmr_Revival.Start();

            return true;
        }
        private bool chickenDie(int x, int y)
        {
            if (this.chickens[y, x] == null) return false;

            changePoint(1);

            this.pnl_Play.Controls.Remove(chickens[y, x]);
            this.chickens[y, x].Dispose();
            this.chickens[y, x] = null;

            return true;
        }
        private bool decreaseHeart()
        {
            if (this.lives <= 0) return false;

            this.pnl_Play.Controls.Remove(hearts[lives - 1]);
            this.hearts.RemoveAt(lives - 1);
            this.lives--;

            return lives > 0;
        }
        private bool removeBullet(int i)
        {
            if (i < 0 || i >= this.bullets.Count) return false;

            this.pnl_Play.Controls.Remove(bullets[i]);
            this.bullets.RemoveAt(i);

            return true;
        }
        private bool removeEgg(int i)
        {
            if (i < 0 || i >= eggs.Count) return false;

            this.pnl_Play.Controls.Remove(eggs[i]);
            this.eggs.RemoveAt(i);

            return true;
        }
        private bool changePoint(int i)
        {
            if (this.score + 10 * i < 0)
            {
                this.score = 0;
                this.lbl_ScorePlay.Text = "Điểm: " + this.score.ToString();
                return true;
            }

            this.score += 10 * i;
            this.lbl_ScorePlay.Text = "Điểm: " + this.score.ToString();
            return true;
        }

        //su kien tren pnl_play
        private void pnl_Play_Paint(object sender, PaintEventArgs e)
        {
            this.pnl_Play.Focus();
        }
        private void pnl_Play_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    ship.Left -= 10;
                    break;
                case Keys.Right:
                    ship.Left += 10;
                    break;
                case Keys.Down:
                    ship.Top += 10;
                    break;
                case Keys.Up:
                    ship.Top -= 10;
                    break;
                case Keys.Space:
                    initialBullet();
                    break;

            }
            this.pnl_Play.Refresh();
        }
        private void tmr_Bullets_Tick(object sender, EventArgs e)
        {
            if (this.bullets.Count == 0) return;
            for (int i = 0; i < this.bullets.Count; ++i)
            {
                bool removed = false;
                this.bullets[i].Top -= this.bullets[i].bulletSpeed;

                for (int x = 0; x < this.cols && !removed; ++x)
                    for (int y = this.rows - 1; y >= 0 && !removed; --y)
                    {
                        if (chickens[y, x] == null) continue;
                        if (chickens[y, x].Bounds.IntersectsWith(bullets[i].Bounds))
                        {
                            chickenDie(x, y);
                            removed = removeBullet(i);
                        }
                    }

                if(!removed && this.bullets[i].Top < 0)
                    removed = removeBullet(i);
            }

        }
        private void tmr_Chickens_Tick(object sender, EventArgs e)
        {
            int revDirect = 1;

            int x1 = -1;
            int y1 = -1;

            int x2 = -1;
            int y2 = -1;

            for (int x = 0; x < this.cols; ++x)
                for (int y = this.rows - 1; y >= 0; --y)
                {
                    if (chickens[y, x] != null)
                    {
                        y2 = y;
                        x2 = x;
                        if (x1 == -1 && y1 == -1)
                        {
                            y1 = y;
                            x1 = x;
                        }
                    }
                }

            if (x1 != -1 && y1 != -1 &&
                (this.chickens[y1, x1].Left < 0 ||
                this.chickens[y2, x2].Left + this.chickens[y2, x2].Width > this.pnl_Play.Width))
                revDirect = -1;

            bool chicken_live = false;
            for (int x = 0; x < this.cols; ++x)
                for (int y = this.rows - 1; y >= 0; --y)
                {
                    if (chickens[y, x] == null) continue;
                    else chicken_live = true;
                    chickens[y, x].nextFrame();
                    chickens[y, x].chickenSpeed *= revDirect;
                    chickens[y, x].Left += chickens[y, x].chickenSpeed;

                    if (chickens[y, x].Bounds.IntersectsWith(ship.Bounds))
                    {
                        shipDie();
                        chickenDie(x, y);
                    }
                }
            if (!chicken_live)
            {
                if (this.level == 1) initialChicken(2);
                else endGame(true);
            }
        }
        private void tme_Eggs_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (rand.Next(100) < 10) initialEgg();
            if (eggs.Count == 0) return;

            for (int i = 0; i < eggs.Count; ++i)
            {
                eggs[i].Top += eggs[i].eggSpeed;

                if (eggs[i].Bounds.IntersectsWith(ship.Bounds))
                {
                    shipDie();
                    removeEgg(i);
                    break;
                }

                //Debug.WriteLine(eggs[i].Top + " " + (this.Height) + " " + (eggs[i].Height));
                if (eggs[i].Top >= this.Height - (eggs[i].Height + 50))
                {
                    eggs[i].eggSpeed = 0;

                    if (eggs[i].nextFrame()) { }
                    else removeEgg(i);
                }
            }
        }
        private void tmr_Revival_Tick(object sender, EventArgs e)
        {
            scintillate = !scintillate;
            if (scintillate) this.ship.Image = Properties.Resources.shipDead;
            else this.ship.Image = Properties.Resources.shipLive;
        }
        private void tmr_WaitRevival_Tick(object sender, EventArgs e)
        {
            this.ship.Image = Properties.Resources.shipLive;
            tmr_Revival.Stop();
            tmr_WaitRevival.Stop();

        }
        private void endGame(bool isWin)
        {
            initialUI_EndGame(isWin);
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            this.initialUI_Play();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Replay_Click(object sender, EventArgs e)
        {
            initialUI_Play();
        }
        private void btn_Menu_Click(object sender, EventArgs e)
        {
            initialUI_Menu();
        }
    }
}
