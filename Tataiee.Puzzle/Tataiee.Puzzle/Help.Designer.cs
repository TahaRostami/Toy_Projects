namespace Tataiee.Puzzle
{
    partial class Help
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
            this.categoryPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.bunifuImageButton1 = new ns1.BunifuImageButton();
            this.btnTutorial = new ns1.BunifuFlatButton();
            this.btnAbout = new ns1.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.categoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryPanel
            // 
            this.categoryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            this.categoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.categoryPanel.Controls.Add(this.bunifuImageButton1);
            this.categoryPanel.Controls.Add(this.label1);
            this.categoryPanel.Controls.Add(this.label2);
            this.categoryPanel.Controls.Add(this.btnAbout);
            this.categoryPanel.Controls.Add(this.btnTutorial);
            this.categoryPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.categoryPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.categoryPanel.Location = new System.Drawing.Point(0, 0);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Size = new System.Drawing.Size(206, 582);
            this.categoryPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(206, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(637, 582);
            this.contentPanel.TabIndex = 1;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton1.Image = global::Tataiee.Puzzle.Properties.Resources.Back_Arrow_32px;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(3, 3);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(47, 46);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 0;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 0;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // btnTutorial
            // 
            this.btnTutorial.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnTutorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            this.btnTutorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTutorial.BorderRadius = 0;
            this.btnTutorial.ButtonText = "Tutorial";
            this.btnTutorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTutorial.DisabledColor = System.Drawing.Color.Gray;
            this.btnTutorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutorial.Iconcolor = System.Drawing.Color.Transparent;
            this.btnTutorial.Iconimage = global::Tataiee.Puzzle.Properties.Resources.Course_32px;
            this.btnTutorial.Iconimage_right = null;
            this.btnTutorial.Iconimage_right_Selected = null;
            this.btnTutorial.Iconimage_Selected = null;
            this.btnTutorial.IconMarginLeft = 0;
            this.btnTutorial.IconMarginRight = 0;
            this.btnTutorial.IconRightVisible = true;
            this.btnTutorial.IconRightZoom = 0D;
            this.btnTutorial.IconVisible = true;
            this.btnTutorial.IconZoom = 90D;
            this.btnTutorial.IsTab = false;
            this.btnTutorial.Location = new System.Drawing.Point(3, 135);
            this.btnTutorial.Name = "btnTutorial";
            this.btnTutorial.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            this.btnTutorial.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnTutorial.OnHoverTextColor = System.Drawing.Color.Snow;
            this.btnTutorial.selected = false;
            this.btnTutorial.Size = new System.Drawing.Size(196, 48);
            this.btnTutorial.TabIndex = 1;
            this.btnTutorial.Text = "Tutorial";
            this.btnTutorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTutorial.Textcolor = System.Drawing.Color.White;
            this.btnTutorial.TextFont = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutorial.Click += new System.EventHandler(this.btnTutorial_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(150)))), ((int)(((byte)(218)))));
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbout.BorderRadius = 0;
            this.btnAbout.ButtonText = "About";
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.DisabledColor = System.Drawing.Color.Gray;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAbout.Iconimage = global::Tataiee.Puzzle.Properties.Resources.About_32px;
            this.btnAbout.Iconimage_right = null;
            this.btnAbout.Iconimage_right_Selected = null;
            this.btnAbout.Iconimage_Selected = null;
            this.btnAbout.IconMarginLeft = 0;
            this.btnAbout.IconMarginRight = 0;
            this.btnAbout.IconRightVisible = true;
            this.btnAbout.IconRightZoom = 0D;
            this.btnAbout.IconVisible = true;
            this.btnAbout.IconZoom = 90D;
            this.btnAbout.IsTab = false;
            this.btnAbout.Location = new System.Drawing.Point(3, 81);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(150)))), ((int)(((byte)(218)))));
            this.btnAbout.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(200)))));
            this.btnAbout.OnHoverTextColor = System.Drawing.Color.Snow;
            this.btnAbout.selected = false;
            this.btnAbout.Size = new System.Drawing.Size(196, 48);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.Textcolor = System.Drawing.Color.White;
            this.btnAbout.TextFont = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.categoryPanel);
            this.Name = "Help";
            this.Size = new System.Drawing.Size(843, 582);
            this.categoryPanel.ResumeLayout(false);
            this.categoryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel categoryPanel;
        private System.Windows.Forms.Panel contentPanel;
        private ns1.BunifuImageButton bunifuImageButton1;
        private ns1.BunifuFlatButton btnTutorial;
        private ns1.BunifuFlatButton btnAbout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
