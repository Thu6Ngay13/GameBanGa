using System.Windows.Forms;

namespace GameBanGa
{
    partial class GUI_GAME
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
            this.lbl_ScorePlay = new System.Windows.Forms.Label();
            this.tmr_Bullets = new System.Windows.Forms.Timer(this.components);
            this.tmr_Chickens = new System.Windows.Forms.Timer(this.components);
            this.tmr_Eggs = new System.Windows.Forms.Timer(this.components);
            this.tmr_WaitRevival = new System.Windows.Forms.Timer(this.components);
            this.tmr_Revival = new System.Windows.Forms.Timer(this.components);
            this.pnl_EndGame = new System.Windows.Forms.Panel();
            this.btn_Menu = new System.Windows.Forms.Button();
            this.btn_Replay = new System.Windows.Forms.Button();
            this.lbl_ScoreEndGame = new System.Windows.Forms.Label();
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.pnl_Play.SuspendLayout();
            this.pnl_EndGame.SuspendLayout();
            this.pnl_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Play
            // 
            this.pnl_Play.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnl_Play.Location = new System.Drawing.Point(1, 1);
            this.pnl_Play.Name = "pnl_Play";
            this.pnl_Play.Size = new System.Drawing.Size(500, 700);
            this.pnl_Play.TabIndex = 0;
            this.pnl_Play.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Play_Paint);
            this.pnl_Play.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pnl_Play_PreviewKeyDown);
            // 
            // lbl_ScorePlay
            // 
            this.lbl_ScorePlay.Location = new System.Drawing.Point(1, 1);
            this.lbl_ScorePlay.Name = "lbl_ScorePlay";
            this.lbl_ScorePlay.Size = new System.Drawing.Size(100, 20);
            this.lbl_ScorePlay.TabIndex = 0;
            this.lbl_ScorePlay.Text = "Điểm: 0";
            // 
            // tmr_Bullets
            // 
            this.tmr_Bullets.Interval = 10;
            this.tmr_Bullets.Tick += new System.EventHandler(this.tmr_Bullets_Tick);
            // 
            // tmr_Chickens
            // 
            this.tmr_Chickens.Interval = 10;
            this.tmr_Chickens.Tick += new System.EventHandler(this.tmr_Chickens_Tick);
            // 
            // tmr_Eggs
            // 
            this.tmr_Eggs.Interval = 10;
            this.tmr_Eggs.Tick += new System.EventHandler(this.tme_Eggs_Tick);
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
            // pnl_EndGame
            // 
            this.pnl_EndGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_EndGame.Controls.Add(this.btn_Menu);
            this.pnl_EndGame.Controls.Add(this.btn_Replay);
            this.pnl_EndGame.Controls.Add(this.lbl_ScoreEndGame);
            this.pnl_EndGame.Location = new System.Drawing.Point(1, 1);
            this.pnl_EndGame.Name = "pnl_EndGame";
            this.pnl_EndGame.Size = new System.Drawing.Size(500, 700);
            this.pnl_EndGame.TabIndex = 0;
            // 
            // btn_Menu
            // 
            this.btn_Menu.Location = new System.Drawing.Point(152, 202);
            this.btn_Menu.Name = "btn_Menu";
            this.btn_Menu.Size = new System.Drawing.Size(200, 50);
            this.btn_Menu.TabIndex = 2;
            this.btn_Menu.Text = "Menu";
            this.btn_Menu.UseVisualStyleBackColor = true;
            this.btn_Menu.Click += new System.EventHandler(this.btn_Menu_Click);
            // 
            // btn_Replay
            // 
            this.btn_Replay.Location = new System.Drawing.Point(152, 146);
            this.btn_Replay.Name = "btn_Replay";
            this.btn_Replay.Size = new System.Drawing.Size(200, 50);
            this.btn_Replay.TabIndex = 1;
            this.btn_Replay.Text = "Replay";
            this.btn_Replay.UseVisualStyleBackColor = true;
            this.btn_Replay.Click += new System.EventHandler(this.btn_Replay_Click);
            // 
            // lbl_ScoreEndGame
            // 
            this.lbl_ScoreEndGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_ScoreEndGame.Location = new System.Drawing.Point(80, 89);
            this.lbl_ScoreEndGame.Name = "lbl_ScoreEndGame";
            this.lbl_ScoreEndGame.Size = new System.Drawing.Size(344, 50);
            this.lbl_ScoreEndGame.TabIndex = 0;
            this.lbl_ScoreEndGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_Menu.Controls.Add(this.btn_Exit);
            this.pnl_Menu.Controls.Add(this.btn_Play);
            this.pnl_Menu.Location = new System.Drawing.Point(1, 1);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(500, 700);
            this.pnl_Menu.TabIndex = 1;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(153, 316);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(200, 50);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(153, 260);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(200, 50);
            this.btn_Play.TabIndex = 0;
            this.btn_Play.Text = "Play";
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // GUI_GAME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(500, 700);
            //this.Controls.Add(this.pnl_Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GUI_GAME";
            this.Text = "Game Bắn Gà";
            this.pnl_Play.ResumeLayout(false);
            this.pnl_EndGame.ResumeLayout(false);
            this.pnl_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ScorePlay;
        private System.Windows.Forms.Label lbl_ScoreEndGame;
        private System.Windows.Forms.Timer tmr_Bullets;
        private System.Windows.Forms.Timer tmr_Chickens;
        private System.Windows.Forms.Timer tmr_Eggs;
        private System.Windows.Forms.Timer tmr_WaitRevival;
        private System.Windows.Forms.Timer tmr_Revival;
        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.Panel pnl_Play;
        private System.Windows.Forms.Panel pnl_EndGame;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Play;
        private Button btn_Replay;
        private Button btn_Menu;
    }
}