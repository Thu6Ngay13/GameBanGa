using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameBanGa
{
    public partial class Form1 : Form
    {
        private Piece rocket;

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
    }
}
