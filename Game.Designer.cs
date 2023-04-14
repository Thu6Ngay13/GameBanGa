namespace GameBanGa
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnl_Play = new System.Windows.Forms.Panel();
            this.tmr_Bullets = new System.Windows.Forms.Timer(this.components);
            this.tmr_Chickens = new System.Windows.Forms.Timer(this.components);
            this.tme_Eggs = new System.Windows.Forms.Timer(this.components);
            this.tmr_WaitRevival = new System.Windows.Forms.Timer(this.components);
            this.tmr_Revival = new System.Windows.Forms.Timer(this.components);
            this.lblDiem = new System.Windows.Forms.Label();
            this.pnl_Play.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Play
            // 
            this.pnl_Play.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnl_Play.Controls.Add(this.lblDiem);
            this.pnl_Play.Location = new System.Drawing.Point(1, 0);
            this.pnl_Play.Name = "pnl_Play";
            this.pnl_Play.Size = new System.Drawing.Size(500, 700);
            this.pnl_Play.TabIndex = 0;
            this.pnl_Play.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Play_Paint);
            this.pnl_Play.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pnl_Play_PreviewKeyDown);
            // 
            // tmr_Bullets
            // 
            this.tmr_Bullets.Enabled = true;
            this.tmr_Bullets.Interval = 10;
            this.tmr_Bullets.Tick += new System.EventHandler(this.tmr_Bullets_Tick);
            // 
            // tmr_Chickens
            // 
            this.tmr_Chickens.Enabled = true;
            this.tmr_Chickens.Interval = 10;
            this.tmr_Chickens.Tick += new System.EventHandler(this.tmr_Chickens_Tick);
            // 
            // tme_Eggs
            // 
            this.tme_Eggs.Enabled = true;
            this.tme_Eggs.Interval = 10;
            this.tme_Eggs.Tick += new System.EventHandler(this.tme_Eggs_Tick);
            // 
            // tmr_WaitRevival
            // 
            this.tmr_WaitRevival.Interval = 3000;
            this.tmr_WaitRevival.Tick += new System.EventHandler(this.tmr_WaitRevival_Tick);
            // 
            // tmr_Revival
            // 
            this.tmr_Revival.Interval = 300;
            this.tmr_Revival.Tick += new System.EventHandler(this.tmr_Revival_Tick);
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Location = new System.Drawing.Point(4, 0);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(95, 16);
            this.lblDiem.TabIndex = 0;
            this.lblDiem.Text = "Điểm của bạn: ";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(498, 699);
            this.Controls.Add(this.pnl_Play);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Game";
            this.Text = "Game";
            this.pnl_Play.ResumeLayout(false);
            this.pnl_Play.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Play;
        private System.Windows.Forms.Timer tmr_Bullets;
        private System.Windows.Forms.Timer tmr_Chickens;
        private System.Windows.Forms.Timer tme_Eggs;
        private System.Windows.Forms.Timer tmr_WaitRevival;
        private System.Windows.Forms.Timer tmr_Revival;
        private System.Windows.Forms.Label lblDiem;
    }
}