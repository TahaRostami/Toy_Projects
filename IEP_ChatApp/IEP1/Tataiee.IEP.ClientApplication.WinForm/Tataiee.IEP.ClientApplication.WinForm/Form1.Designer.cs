namespace Tataiee.IEP.ClientApplication.WinForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUname = new System.Windows.Forms.Label();
            this.rdbLoginReg = new System.Windows.Forms.RadioButton();
            this.rdbLogin = new System.Windows.Forms.RadioButton();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.btnLoginRegister = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chbSendToAll = new System.Windows.Forms.CheckBox();
            this.lstOnlineUsers = new System.Windows.Forms.ListBox();
            this.txtMsgBox = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnList = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 526);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login & Register";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblUname);
            this.groupBox1.Controls.Add(this.rdbLoginReg);
            this.groupBox1.Controls.Add(this.rdbLogin);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtUname);
            this.groupBox1.Controls.Add(this.btnLoginRegister);
            this.groupBox1.Location = new System.Drawing.Point(26, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 353);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Register";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(86, 111);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            // 
            // lblUname
            // 
            this.lblUname.AutoSize = true;
            this.lblUname.Location = new System.Drawing.Point(86, 39);
            this.lblUname.Name = "lblUname";
            this.lblUname.Size = new System.Drawing.Size(73, 17);
            this.lblUname.TabIndex = 5;
            this.lblUname.Text = "Username";
            // 
            // rdbLoginReg
            // 
            this.rdbLoginReg.AutoSize = true;
            this.rdbLoginReg.Checked = true;
            this.rdbLoginReg.Location = new System.Drawing.Point(159, 263);
            this.rdbLoginReg.Name = "rdbLoginReg";
            this.rdbLoginReg.Size = new System.Drawing.Size(149, 21);
            this.rdbLoginReg.TabIndex = 4;
            this.rdbLoginReg.TabStop = true;
            this.rdbLoginReg.Text = "Login and Register";
            this.rdbLoginReg.UseVisualStyleBackColor = true;
            // 
            // rdbLogin
            // 
            this.rdbLogin.AutoSize = true;
            this.rdbLogin.Location = new System.Drawing.Point(89, 263);
            this.rdbLogin.Name = "rdbLogin";
            this.rdbLogin.Size = new System.Drawing.Size(64, 21);
            this.rdbLogin.TabIndex = 3;
            this.rdbLogin.Text = "Login";
            this.rdbLogin.UseVisualStyleBackColor = true;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(86, 137);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(222, 22);
            this.txtPass.TabIndex = 2;
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(86, 73);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(222, 22);
            this.txtUname.TabIndex = 1;
            // 
            // btnLoginRegister
            // 
            this.btnLoginRegister.Location = new System.Drawing.Point(86, 202);
            this.btnLoginRegister.Name = "btnLoginRegister";
            this.btnLoginRegister.Size = new System.Drawing.Size(222, 34);
            this.btnLoginRegister.TabIndex = 0;
            this.btnLoginRegister.Text = "REQUEST";
            this.btnLoginRegister.UseVisualStyleBackColor = true;
            this.btnLoginRegister.Click += new System.EventHandler(this.btnLoginRegister_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnList);
            this.tabPage2.Controls.Add(this.chbSendToAll);
            this.tabPage2.Controls.Add(this.lstOnlineUsers);
            this.tabPage2.Controls.Add(this.txtMsgBox);
            this.tabPage2.Controls.Add(this.txtMsg);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chat";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chbSendToAll
            // 
            this.chbSendToAll.AutoSize = true;
            this.chbSendToAll.Location = new System.Drawing.Point(346, 406);
            this.chbSendToAll.Name = "chbSendToAll";
            this.chbSendToAll.Size = new System.Drawing.Size(103, 21);
            this.chbSendToAll.TabIndex = 3;
            this.chbSendToAll.Text = "Send To All";
            this.chbSendToAll.UseVisualStyleBackColor = true;
            // 
            // lstOnlineUsers
            // 
            this.lstOnlineUsers.FormattingEnabled = true;
            this.lstOnlineUsers.ItemHeight = 16;
            this.lstOnlineUsers.Location = new System.Drawing.Point(346, 42);
            this.lstOnlineUsers.Name = "lstOnlineUsers";
            this.lstOnlineUsers.Size = new System.Drawing.Size(217, 356);
            this.lstOnlineUsers.TabIndex = 2;
            // 
            // txtMsgBox
            // 
            this.txtMsgBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtMsgBox.Location = new System.Drawing.Point(8, 96);
            this.txtMsgBox.Multiline = true;
            this.txtMsgBox.Name = "txtMsgBox";
            this.txtMsgBox.ReadOnly = true;
            this.txtMsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgBox.Size = new System.Drawing.Size(301, 318);
            this.txtMsgBox.TabIndex = 1;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(8, 42);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(301, 22);
            this.txtMsg.TabIndex = 0;
            this.txtMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDownAsync);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 43);
            this.panel1.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(27, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 0;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(455, 404);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(108, 23);
            this.btnList.TabIndex = 4;
            this.btnList.Text = "LIST";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 526);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(602, 573);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(602, 573);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IEP1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.Button btnLoginRegister;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rdbLoginReg;
        private System.Windows.Forms.RadioButton rdbLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtMsgBox;
        private System.Windows.Forms.ListBox lstOnlineUsers;
        private System.Windows.Forms.CheckBox chbSendToAll;
        private System.Windows.Forms.Button btnList;
    }
}

