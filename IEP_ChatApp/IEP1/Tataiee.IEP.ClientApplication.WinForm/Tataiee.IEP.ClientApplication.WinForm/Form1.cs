using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tataiee.IEP.ClientApplication.WinForm
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer;
        //const int BUFFER_SIZE = 1024;
        TcpClient client;
        string connectionId = string.Empty;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(client!=null && client.Connected)
            {
                
            }
            else
            {
                lblStatus.Text = "Disconnected:(";
                tabControl1.SelectTab(0);
                timer.Enabled = false;
                txtPass.Enabled = true;
                txtUname.Enabled = true;
            }
        }

        private async void btnLoginRegister_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);            

            if (txtUname.Text.Contains('$') || txtUname.Text.Contains('@') || txtUname.Text.Contains('#'))
                return;
            txtUname.Enabled = false;
            txtPass.Enabled = false;
            btn.Enabled = false;


            string resAck1 = string.Empty;
            string connId = string.Empty;

            string cmd = rdbLogin.Checked ? "LOGIN" : "REGISTER";

            string username = txtUname.Text;
            string password = txtPass.Text;

            if (client == null || !client.Connected)
            {
                try
                {
                    client = new TcpClient();
                    await client.ConnectAsync("127.0.0.1", 2018);

                    NetworkStream ns = client.GetStream();
                    StreamReader sr = new StreamReader(ns);
                    StreamWriter sw = new StreamWriter(ns);
                    await sw.WriteLineAsync(cmd);
                    await sw.WriteLineAsync(username);
                    await sw.WriteLineAsync(password);
                    await sw.FlushAsync();

                    resAck1 = await sr.ReadLineAsync();
                    connId = await sr.ReadLineAsync();

                    connectionId = connId;

                    if (resAck1 == "FAILED")
                    {
                        lblStatus.Text = "Failed:/";
                        if (client != null)
                        {
                            client.Close();
                            client = null;
                        }
                        txtUname.Enabled = true;
                        txtPass.Enabled = true;

                    }
                    else if (resAck1 == "OK_REGISTER_AND_LOGIN")
                    {
                        lblStatus.Text = "REGISTER_AND_LOGIN!";
                        Thread th = new Thread(RcvMsg) { IsBackground = true };
                        th.Start();

                    }
                    else if (resAck1 == "LOGIN_OK")
                    {
                        lblStatus.Text = "LOGIN!";
                        Thread th = new Thread(RcvMsg) { IsBackground = true };
                        th.Start();
                    }
                    else
                    {

                    }

                }
                catch
                {

                }

                if (resAck1 == "OK_REGISTER_AND_LOGIN" || resAck1 == "LOGIN_OK")
                {
                    Thread.Sleep(30);
                    await ListAsync();
                    tabControl1.SelectTab(1);
                    if (timer == null)
                    {
                        timer = new System.Windows.Forms.Timer();
                        timer.Tick += Timer_Tick;
                        timer.Interval = 1000;
                        timer.Enabled = true;
                        timer.Start();
                    }
                    else
                    {
                        timer.Enabled = true;
                        timer.Start();
                    }
                }

            }
            btn.Enabled = true;            
        }

        private void RcvMsg()
        {
            while (client != null && client.Connected)
            {
                if (client.Available > 0)
                {
                    string rcvMsg = string.Empty;
                    //lock (sync)
                    //{

                    StreamReader sr = new StreamReader(client.GetStream());
                    rcvMsg = sr.ReadLine();
                    //sr.Close();
                    //}

                    string[] msg = rcvMsg.Split('#');

                    string from = msg[0];
                    string to = msg[1];
                    string txt = msg[2];

                    if (from == "$LIST")
                    {
                        string[] uns = txt.Split('@');
                        lstOnlineUsers.Items.Clear();
                        for (int i = 0; i < uns.Length; i++)
                        {
                            lstOnlineUsers.Items.Add(uns[i]);
                        }
                        lstOnlineUsers.Invalidate();
                    }
                    else
                    {
                        //this.Invoke(new Action(() => {
                        string text = txtMsgBox.Text;
                        text += Environment.NewLine + from + ":" + txt;
                        txtMsgBox.Text = text;
                        txtMsgBox.Invalidate();
                        //}));
                    }


                }
            }
        }

        private async void textBox1_KeyDownAsync(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string from = txtUname.Text;
                string to = txtUname.Text;//to me
                string msg = txtMsg.Text;

                txtMsg.Clear();

                if (lstOnlineUsers.SelectedIndex >= 0)
                {
                    to = lstOnlineUsers.Items[lstOnlineUsers.SelectedIndex].ToString();
                }
                if (chbSendToAll.Checked)
                {
                    to = "$ALL";
                }

                await SendAsync(from, to, msg);

            }
        }

        private async void btnList_Click(object sender, EventArgs e)
        {
            await ListAsync();
        }

        private async Task SendAsync(string from, string to, string msg)
        {
            try
            {
                string MSG = $"{from}#{to}#{msg}";
                if (client != null && client.Connected)
                {
                    StreamWriter sw = new StreamWriter(client.GetStream());
                    await sw.WriteLineAsync(MSG);
                    await sw.FlushAsync();
                    //sw.Close();
                }
            }
            catch
            {
                MessageBox.Show(":/");
            }
        }
        private async Task ListAsync()
        {
            string from = txtUname.Text;
            string to = txtUname.Text;//to me
            string msg = "$LIST";

            try
            {
                string MSG = $"{from}#{to}#{msg}";
                if (client != null && client.Connected)
                {
                    StreamWriter sw = new StreamWriter(client.GetStream());
                    await sw.WriteLineAsync(MSG);
                    await sw.FlushAsync();
                    //sw.Close();
                }
            }
            catch
            {
                MessageBox.Show(":/");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null && client.Connected)
            {
                try
                {
                    string MSG = $"$BYE#$BYE#$BYE";
                    StreamWriter sw = new StreamWriter(client.GetStream());
                    sw.WriteLine(MSG);
                    sw.Flush();
                    //sw.Close();
                }
                catch
                {
                    MessageBox.Show(":/");
                }
                client.Close();
            }
        }
    }
}
