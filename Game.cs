using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace GameBanGa
{
    public partial class Game : Form
    {
        private Ship ship;
        private Hearts he;
        private Chicken[,] chickens;
        private List<Egg> eggs;
        private List<Bullet> bullets;
        private List<Hearts> hearts;

        private int rows;
        private int cols;
        private int[] topChicken;

        private bool scintillate;

        public Game()
        {
            InitializeComponent();
            initial();
        }

        //Khoi tao cac doi tuong trong game
        private void initial()
        {
            initialShip();
            initialChicken(3, 8);
            createHeart();
        }

        private void createHeart()
        {
            
            for (int i = 0;i <3; i++)
            {
                he = new Hearts(30, 30, Properties.Resources.heartLive);
                he.Left = this.pnl_Play.Width / 2 + 155 - (30*i);
                he.Top = this.pnl_Play.Height / 2 - 285 ;
                this.pnl_Play.Controls.Add(he);

            }

        }
        private void initialShip()
        {
            this.ship = new Ship(50, 50, Properties.Resources.shipLive);
            this.ship.Left = this.pnl_Play.Width / 2 - ship.Width / 2;
            this.ship.Top = this.pnl_Play.Height - ship.Height;
            this.bullets = new List<Bullet>();
            this.scintillate = false;

            this.pnl_Play.Controls.Add(ship);
        }
        private void initialBullet()
        {
            Bullet bullet = new Bullet(5, 15, Properties.Resources.b1, 10);
            bullet.Left = this.ship.Left + this.ship.Width / 2 - bullet.Width / 2;
            bullet.Top = this.ship.Top - bullet.Height;

            this.bullets.Add(bullet);
            this.pnl_Play.Controls.Add(bullet);
        }
        private void initialChicken(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.chickens = new Chicken[rows, cols];
            this.topChicken = new int[cols];

            for (int x = 0; x < cols; ++x)
            {
                this.topChicken[x] = rows - 1;
                for (int y = rows-1; y >= 0; --y)
                {
                    Chicken chicken = new Chicken(30, 30, Properties.Resources.chickenRed, 10, 0, 3);
                    chicken.Left = x * 30; //khoang cach theo chieu x giua cac con ga la 30
                    chicken.Top = y * 30 + chicken.Height; //khoang cach theo chieu y cua cac con la 30

                    this.chickens[y, x] = chicken;
                    this.pnl_Play.Controls.Add(chicken);
                }
            }
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
            for (int i = 0; i < this.bullets.Count; ++i)
            {
                this.bullets[i].Top -= this.bullets[i].bulletSpeed;
                if (this.bullets[i].Top < 0)
                {
                    this.pnl_Play.Controls.Remove(bullets[i]);
                    this.bullets.RemoveAt(i);
                    --i;
                }
            }
        }
        private void tmr_Chickens_Tick(object sender, EventArgs e)
        {
            int revDirect = 1;
            if (this.chickens[0, 0].Left < 0 ||
                this.chickens[0, 0].Left + this.cols * 30 > this.pnl_Play.Width) 
                revDirect = -1;

            Debug.WriteLine(chickens[0, 0].Left + " " + chickens[rows - 1, cols - 1].Right);

            for (int x = 0; x < cols; ++x)
                for (int y = rows - 1; y >= 0; --y)
                {
                    if (chickens[y, x] == null) continue;
                    chickens[y, x].nextFrame();
                    chickens[y, x].chickenSpeed *= revDirect; 
                    chickens[y, x].Left += chickens[y, x].chickenSpeed;
                    if (chickens[y, x].Bounds.IntersectsWith(ship.Bounds))
                    {
                        tmr_Revival.Start();
                        tmr_WaitRevival.Start();
                    }
                }
        }
        private void tme_Eggs_Tick(object sender, EventArgs e)
        {

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
    }
}
