namespace Tataiee.Puzzle
{
    partial class UCPictureSelect
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
            this.imageSelector = new ns1.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageRemove = new ns1.BunifuImageButton();
            this.imageEditor = new ns1.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // imageSelector
            // 
            this.imageSelector.BackColor = System.Drawing.Color.Transparent;
            this.imageSelector.Enabled = false;
            this.imageSelector.Image = global::Tataiee.Puzzle.Properties.Resources.Image_File_48px;
            this.imageSelector.ImageActive = null;
            this.imageSelector.Location = new System.Drawing.Point(496, 72);
            this.imageSelector.Name = "imageSelector";
            this.imageSelector.Size = new System.Drawing.Size(56, 49);
            this.imageSelector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageSelector.TabIndex = 1;
            this.imageSelector.TabStop = false;
            this.imageSelector.Zoom = 10;
            this.imageSelector.Click += new System.EventHandler(this.imageSelector_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Tataiee.Puzzle.Properties.Resources.img1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(159, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // imageRemove
            // 
            this.imageRemove.BackColor = System.Drawing.Color.Transparent;
            this.imageRemove.Image = global::Tataiee.Puzzle.Properties.Resources.Remove_Image_48px;
            this.imageRemove.ImageActive = null;
            this.imageRemove.Location = new System.Drawing.Point(496, 323);
            this.imageRemove.Name = "imageRemove";
            this.imageRemove.Size = new System.Drawing.Size(56, 49);
            this.imageRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageRemove.TabIndex = 2;
            this.imageRemove.TabStop = false;
            this.imageRemove.Zoom = 10;
            this.imageRemove.Click += new System.EventHandler(this.imageRemove_Click);
            // 
            // imageEditor
            // 
            this.imageEditor.BackColor = System.Drawing.Color.Transparent;
            this.imageEditor.Image = global::Tataiee.Puzzle.Properties.Resources.Edit_Image_48px;
            this.imageEditor.ImageActive = null;
            this.imageEditor.Location = new System.Drawing.Point(496, 198);
            this.imageEditor.Name = "imageEditor";
            this.imageEditor.Size = new System.Drawing.Size(56, 49);
            this.imageEditor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageEditor.TabIndex = 2;
            this.imageEditor.TabStop = false;
            this.imageEditor.Zoom = 10;
            this.imageEditor.Click += new System.EventHandler(this.imageEditor_Click);
            // 
            // UCPictureSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Controls.Add(this.imageEditor);
            this.Controls.Add(this.imageRemove);
            this.Controls.Add(this.imageSelector);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UCPictureSelect";
            this.Size = new System.Drawing.Size(632, 430);
            ((System.ComponentModel.ISupportInitialize)(this.imageSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ns1.BunifuImageButton imageSelector;
        private ns1.BunifuImageButton imageRemove;
        private ns1.BunifuImageButton imageEditor;
    }
}
