namespace Tataiee.Puzzle
{
    partial class UCGame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnShowHelp = new ns1.BunifuImageButton();
            this.btnCloseHelp = new ns1.BunifuImageButton();
            this.stepTitle = new ns1.BunifuCustomLabel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.HelperPanel = new System.Windows.Forms.Panel();
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseHelp)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 505);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(632, 75);
            this.bottomPanel.TabIndex = 2;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.btnShowHelp);
            this.topPanel.Controls.Add(this.btnCloseHelp);
            this.topPanel.Controls.Add(this.stepTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(632, 75);
            this.topPanel.TabIndex = 3;
            // 
            // btnShowHelp
            // 
            this.btnShowHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnShowHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHelp.Image = global::Tataiee.Puzzle.Properties.Resources.Help_48px;
            this.btnShowHelp.ImageActive = null;
            this.btnShowHelp.Location = new System.Drawing.Point(560, 3);
            this.btnShowHelp.Name = "btnShowHelp";
            this.btnShowHelp.Size = new System.Drawing.Size(69, 66);
            this.btnShowHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnShowHelp.TabIndex = 2;
            this.btnShowHelp.TabStop = false;
            this.btnShowHelp.Zoom = 10;
            this.btnShowHelp.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // btnCloseHelp
            // 
            this.btnCloseHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseHelp.Image = global::Tataiee.Puzzle.Properties.Resources.Close_Window_48px;
            this.btnCloseHelp.ImageActive = null;
            this.btnCloseHelp.Location = new System.Drawing.Point(560, 3);
            this.btnCloseHelp.Name = "btnCloseHelp";
            this.btnCloseHelp.Size = new System.Drawing.Size(69, 66);
            this.btnCloseHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCloseHelp.TabIndex = 1;
            this.btnCloseHelp.TabStop = false;
            this.btnCloseHelp.Zoom = 10;
            this.btnCloseHelp.Click += new System.EventHandler(this.btnCloseHelp_Click);
            // 
            // stepTitle
            // 
            this.stepTitle.AutoSize = true;
            this.stepTitle.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.stepTitle.Location = new System.Drawing.Point(294, 27);
            this.stepTitle.Name = "stepTitle";
            this.stepTitle.Size = new System.Drawing.Size(57, 23);
            this.stepTitle.TabIndex = 0;
            this.stepTitle.Text = "Game";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.mainPanel.Controls.Add(this.BoardPanel);
            this.mainPanel.Controls.Add(this.HelperPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 75);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(632, 430);
            this.mainPanel.TabIndex = 4;
            // 
            // HelperPanel
            // 
            this.HelperPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelperPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelperPanel.Location = new System.Drawing.Point(65, 48);
            this.HelperPanel.Name = "HelperPanel";
            this.HelperPanel.Size = new System.Drawing.Size(471, 292);
            this.HelperPanel.TabIndex = 0;
            // 
            // BoardPanel
            // 
            this.BoardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.BoardPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BoardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoardPanel.Location = new System.Drawing.Point(15, 27);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(600, 375);
            this.BoardPanel.TabIndex = 2;
            // 
            // UCGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.Name = "UCGame";
            this.Size = new System.Drawing.Size(632, 580);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseHelp)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel topPanel;
        private ns1.BunifuCustomLabel stepTitle;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel HelperPanel;
        private System.Windows.Forms.Panel BoardPanel;
        private ns1.BunifuImageButton btnCloseHelp;
        private ns1.BunifuImageButton btnShowHelp;
    }
}
