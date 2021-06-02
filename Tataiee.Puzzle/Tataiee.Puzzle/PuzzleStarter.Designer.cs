namespace Tataiee.Puzzle
{
    partial class PuzzleStarter
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.stepTitle = new ns1.BunifuCustomLabel();
            this.NextStep = new ns1.BunifuImageButton();
            this.BeforeStep = new ns1.BunifuImageButton();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NextStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeStep)).BeginInit();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.NextStep);
            this.bottomPanel.Controls.Add(this.BeforeStep);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 505);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(632, 75);
            this.bottomPanel.TabIndex = 2;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.stepTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(632, 75);
            this.topPanel.TabIndex = 3;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 75);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(632, 430);
            this.mainPanel.TabIndex = 4;
            // 
            // stepTitle
            // 
            this.stepTitle.AutoSize = true;
            this.stepTitle.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.stepTitle.Location = new System.Drawing.Point(248, 27);
            this.stepTitle.Name = "stepTitle";
            this.stepTitle.Size = new System.Drawing.Size(90, 23);
            this.stepTitle.TabIndex = 0;
            this.stepTitle.Text = "Step Title";
            // 
            // NextStep
            // 
            this.NextStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NextStep.BackColor = System.Drawing.Color.Transparent;
            this.NextStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextStep.Image = global::Tataiee.Puzzle.Properties.Resources.Sort_Right_48px;
            this.NextStep.ImageActive = null;
            this.NextStep.Location = new System.Drawing.Point(552, 6);
            this.NextStep.Name = "NextStep";
            this.NextStep.Size = new System.Drawing.Size(65, 65);
            this.NextStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NextStep.TabIndex = 0;
            this.NextStep.TabStop = false;
            this.NextStep.Zoom = 10;
            this.NextStep.Click += new System.EventHandler(this.NextStep_Click);
            // 
            // BeforeStep
            // 
            this.BeforeStep.BackColor = System.Drawing.Color.Transparent;
            this.BeforeStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BeforeStep.Image = global::Tataiee.Puzzle.Properties.Resources.Sort_Left_48px;
            this.BeforeStep.ImageActive = null;
            this.BeforeStep.Location = new System.Drawing.Point(18, 6);
            this.BeforeStep.Name = "BeforeStep";
            this.BeforeStep.Size = new System.Drawing.Size(65, 65);
            this.BeforeStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BeforeStep.TabIndex = 1;
            this.BeforeStep.TabStop = false;
            this.BeforeStep.Zoom = 10;
            this.BeforeStep.Click += new System.EventHandler(this.BeforeStep_Click);
            // 
            // PuzzleStarter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.Name = "PuzzleStarter";
            this.Size = new System.Drawing.Size(632, 580);
            this.bottomPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NextStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ns1.BunifuImageButton NextStep;
        private ns1.BunifuImageButton BeforeStep;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel topPanel;
        private ns1.BunifuCustomLabel stepTitle;
        private System.Windows.Forms.Panel mainPanel;
    }
}
