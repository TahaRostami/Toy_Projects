namespace Tataiee.Puzzle
{
    partial class Form1
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
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.puzzleStarter1 = new Tataiee.Puzzle.PuzzleStarter();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btnExit = new ns1.BunifuFlatButton();
            this.lblLogo = new ns1.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelpAndAbout = new ns1.BunifuFlatButton();
            this.btnCurrentGame = new ns1.BunifuFlatButton();
            this.btnCreateNewGame = new ns1.BunifuFlatButton();
            this.ContainerPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ContainerPanel.Controls.Add(this.mainPanel);
            this.ContainerPanel.Controls.Add(this.leftPanel);
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(843, 582);
            this.ContainerPanel.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.puzzleStarter1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(206, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(637, 582);
            this.mainPanel.TabIndex = 1;
            // 
            // puzzleStarter1
            // 
            this.puzzleStarter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.puzzleStarter1.Location = new System.Drawing.Point(0, 0);
            this.puzzleStarter1.Name = "puzzleStarter1";
            this.puzzleStarter1.Size = new System.Drawing.Size(637, 582);
            this.puzzleStarter1.TabIndex = 2;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            this.leftPanel.Controls.Add(this.btnExit);
            this.leftPanel.Controls.Add(this.lblLogo);
            this.leftPanel.Controls.Add(this.panel1);
            this.leftPanel.Controls.Add(this.btnHelpAndAbout);
            this.leftPanel.Controls.Add(this.btnCurrentGame);
            this.leftPanel.Controls.Add(this.btnCreateNewGame);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(206, 582);
            this.leftPanel.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.BorderRadius = 0;
            this.btnExit.ButtonText = "Exit";
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DisabledColor = System.Drawing.Color.Gray;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Iconcolor = System.Drawing.Color.Transparent;
            this.btnExit.Iconimage = global::Tataiee.Puzzle.Properties.Resources.Close_Window_48px;
            this.btnExit.Iconimage_right = null;
            this.btnExit.Iconimage_right_Selected = null;
            this.btnExit.Iconimage_Selected = null;
            this.btnExit.IconMarginLeft = 0;
            this.btnExit.IconMarginRight = 0;
            this.btnExit.IconRightVisible = true;
            this.btnExit.IconRightZoom = 0D;
            this.btnExit.IconVisible = true;
            this.btnExit.IconZoom = 90D;
            this.btnExit.IsTab = false;
            this.btnExit.Location = new System.Drawing.Point(4, 360);
            this.btnExit.Name = "btnExit";
            this.btnExit.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            this.btnExit.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnExit.OnHoverTextColor = System.Drawing.Color.Snow;
            this.btnExit.selected = false;
            this.btnExit.Size = new System.Drawing.Size(196, 48);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Textcolor = System.Drawing.Color.White;
            this.btnExit.TextFont = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(12, 39);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(91, 18);
            this.lblLogo.TabIndex = 4;
            this.lblLogo.Text = "Simple Puzzle";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Tataiee.Puzzle.Properties.Resources.Puzzle_48px;
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(50, 50);
            this.panel1.TabIndex = 3;
            // 
            // btnHelpAndAbout
            // 
            this.btnHelpAndAbout.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnHelpAndAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            this.btnHelpAndAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelpAndAbout.BorderRadius = 0;
            this.btnHelpAndAbout.ButtonText = "Help";
            this.btnHelpAndAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelpAndAbout.DisabledColor = System.Drawing.Color.Gray;
            this.btnHelpAndAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelpAndAbout.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHelpAndAbout.Iconimage = global::Tataiee.Puzzle.Properties.Resources.Help_48px;
            this.btnHelpAndAbout.Iconimage_right = null;
            this.btnHelpAndAbout.Iconimage_right_Selected = null;
            this.btnHelpAndAbout.Iconimage_Selected = null;
            this.btnHelpAndAbout.IconMarginLeft = 0;
            this.btnHelpAndAbout.IconMarginRight = 0;
            this.btnHelpAndAbout.IconRightVisible = true;
            this.btnHelpAndAbout.IconRightZoom = 0D;
            this.btnHelpAndAbout.IconVisible = true;
            this.btnHelpAndAbout.IconZoom = 90D;
            this.btnHelpAndAbout.IsTab = false;
            this.btnHelpAndAbout.Location = new System.Drawing.Point(3, 291);
            this.btnHelpAndAbout.Name = "btnHelpAndAbout";
            this.btnHelpAndAbout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            this.btnHelpAndAbout.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnHelpAndAbout.OnHoverTextColor = System.Drawing.Color.Snow;
            this.btnHelpAndAbout.selected = false;
            this.btnHelpAndAbout.Size = new System.Drawing.Size(196, 48);
            this.btnHelpAndAbout.TabIndex = 2;
            this.btnHelpAndAbout.Text = "Help";
            this.btnHelpAndAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelpAndAbout.Textcolor = System.Drawing.Color.White;
            this.btnHelpAndAbout.TextFont = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelpAndAbout.Click += new System.EventHandler(this.btnHelpAndAbout_Click);
            // 
            // btnCurrentGame
            // 
            this.btnCurrentGame.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnCurrentGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            this.btnCurrentGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCurrentGame.BorderRadius = 0;
            this.btnCurrentGame.ButtonText = "Current Game";
            this.btnCurrentGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCurrentGame.DisabledColor = System.Drawing.Color.Gray;
            this.btnCurrentGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrentGame.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCurrentGame.Iconimage = global::Tataiee.Puzzle.Properties.Resources.Controller_48px;
            this.btnCurrentGame.Iconimage_right = null;
            this.btnCurrentGame.Iconimage_right_Selected = null;
            this.btnCurrentGame.Iconimage_Selected = null;
            this.btnCurrentGame.IconMarginLeft = 0;
            this.btnCurrentGame.IconMarginRight = 0;
            this.btnCurrentGame.IconRightVisible = true;
            this.btnCurrentGame.IconRightZoom = 0D;
            this.btnCurrentGame.IconVisible = true;
            this.btnCurrentGame.IconZoom = 90D;
            this.btnCurrentGame.IsTab = false;
            this.btnCurrentGame.Location = new System.Drawing.Point(3, 218);
            this.btnCurrentGame.Name = "btnCurrentGame";
            this.btnCurrentGame.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            this.btnCurrentGame.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnCurrentGame.OnHoverTextColor = System.Drawing.Color.Snow;
            this.btnCurrentGame.selected = false;
            this.btnCurrentGame.Size = new System.Drawing.Size(196, 48);
            this.btnCurrentGame.TabIndex = 1;
            this.btnCurrentGame.Text = "Current Game";
            this.btnCurrentGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrentGame.Textcolor = System.Drawing.Color.White;
            this.btnCurrentGame.TextFont = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrentGame.Click += new System.EventHandler(this.btnCurrentGame_Click);
            // 
            // btnCreateNewGame
            // 
            this.btnCreateNewGame.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnCreateNewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(150)))), ((int)(((byte)(218)))));
            this.btnCreateNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateNewGame.BorderRadius = 0;
            this.btnCreateNewGame.ButtonText = "Create a new game";
            this.btnCreateNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateNewGame.DisabledColor = System.Drawing.Color.Gray;
            this.btnCreateNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewGame.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCreateNewGame.Iconimage = global::Tataiee.Puzzle.Properties.Resources.Create_New_48px;
            this.btnCreateNewGame.Iconimage_right = null;
            this.btnCreateNewGame.Iconimage_right_Selected = null;
            this.btnCreateNewGame.Iconimage_Selected = null;
            this.btnCreateNewGame.IconMarginLeft = 0;
            this.btnCreateNewGame.IconMarginRight = 0;
            this.btnCreateNewGame.IconRightVisible = true;
            this.btnCreateNewGame.IconRightZoom = 0D;
            this.btnCreateNewGame.IconVisible = true;
            this.btnCreateNewGame.IconZoom = 90D;
            this.btnCreateNewGame.IsTab = false;
            this.btnCreateNewGame.Location = new System.Drawing.Point(4, 149);
            this.btnCreateNewGame.Name = "btnCreateNewGame";
            this.btnCreateNewGame.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(150)))), ((int)(((byte)(218)))));
            this.btnCreateNewGame.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnCreateNewGame.OnHoverTextColor = System.Drawing.Color.Snow;
            this.btnCreateNewGame.selected = false;
            this.btnCreateNewGame.Size = new System.Drawing.Size(196, 48);
            this.btnCreateNewGame.TabIndex = 0;
            this.btnCreateNewGame.Text = "Create a new game";
            this.btnCreateNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewGame.Textcolor = System.Drawing.Color.White;
            this.btnCreateNewGame.TextFont = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewGame.Click += new System.EventHandler(this.btnCreateNewGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 582);
            this.Controls.Add(this.ContainerPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(859, 621);
            this.MinimumSize = new System.Drawing.Size(859, 621);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Puzzle";
            this.ContainerPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.Panel mainPanel;
        private PuzzleStarter puzzleStarter1;
        private System.Windows.Forms.Panel leftPanel;
        private ns1.BunifuFlatButton btnCreateNewGame;
        private ns1.BunifuFlatButton btnHelpAndAbout;
        private ns1.BunifuFlatButton btnCurrentGame;
        private System.Windows.Forms.Panel panel1;
        private ns1.BunifuCustomLabel lblLogo;
        private ns1.BunifuFlatButton btnExit;
    }
}

