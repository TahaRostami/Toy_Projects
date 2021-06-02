namespace Tataiee.Puzzle
{
    partial class UCPictureSize
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
            this.pictureBoxHEW = new System.Windows.Forms.PictureBox();
            this.pictureBoxHGW = new System.Windows.Forms.PictureBox();
            this.pictureBoxHLW = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHGW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHLW)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxHEW
            // 
            this.pictureBoxHEW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxHEW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHEW.Location = new System.Drawing.Point(24, 40);
            this.pictureBoxHEW.Name = "pictureBoxHEW";
            this.pictureBoxHEW.Size = new System.Drawing.Size(140, 140);
            this.pictureBoxHEW.TabIndex = 0;
            this.pictureBoxHEW.TabStop = false;
            this.pictureBoxHEW.Click += new System.EventHandler(this.pictureBoxHEW_Click);
            // 
            // pictureBoxHGW
            // 
            this.pictureBoxHGW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxHGW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHGW.Location = new System.Drawing.Point(22, 28);
            this.pictureBoxHGW.Name = "pictureBoxHGW";
            this.pictureBoxHGW.Size = new System.Drawing.Size(140, 170);
            this.pictureBoxHGW.TabIndex = 1;
            this.pictureBoxHGW.TabStop = false;
            this.pictureBoxHGW.Click += new System.EventHandler(this.pictureBoxHEW_Click);
            // 
            // pictureBoxHLW
            // 
            this.pictureBoxHLW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxHLW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHLW.Location = new System.Drawing.Point(9, 45);
            this.pictureBoxHLW.Name = "pictureBoxHLW";
            this.pictureBoxHLW.Size = new System.Drawing.Size(170, 140);
            this.pictureBoxHLW.TabIndex = 2;
            this.pictureBoxHLW.TabStop = false;
            this.pictureBoxHLW.Click += new System.EventHandler(this.pictureBoxHEW_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.pictureBoxHEW);
            this.panel1.Location = new System.Drawing.Point(22, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 227);
            this.panel1.TabIndex = 3;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.Controls.Add(this.pictureBoxHGW);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(217, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 227);
            this.panel2.TabIndex = 4;
            this.panel2.Click += new System.EventHandler(this.panel1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel3.Controls.Add(this.pictureBoxHLW);
            this.panel3.Location = new System.Drawing.Point(423, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 227);
            this.panel3.TabIndex = 5;
            this.panel3.Click += new System.EventHandler(this.panel1_Click);
            // 
            // UCPictureSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UCPictureSize";
            this.Size = new System.Drawing.Size(632, 430);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHGW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHLW)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHEW;
        private System.Windows.Forms.PictureBox pictureBoxHGW;
        private System.Windows.Forms.PictureBox pictureBoxHLW;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
