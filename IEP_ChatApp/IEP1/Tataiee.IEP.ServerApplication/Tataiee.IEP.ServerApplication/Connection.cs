using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tataiee.IEP.ServerApplication
{

    public class Connection
    {
        //readonly object sync = new object();

       // const int BUFFER_SIZE = 1024;

        public List<Message> messageQueue = new List<Message>();
        public string ConnectionId { get; private set; }
        Program program;
        public TcpClient TcpConnection { get; private set; }
        public Connection(Program prog, TcpClient client)
        {
            program = prog;
            TcpConnection = client;
            ConnectionId = Guid.NewGuid().ToString();
        }
        public void Start()
        {
            SendOnlineListForAllOnlineUser();
            Thread rcvThread = new Thread(RcvFromConnection) { IsBackground = true };
            rcvThread.Start();
            Thread sndThread = new Thread(SndToConnection) { IsBackground = true };
            sndThread.Start();
        }

        public void Add(Message msg)
        {
            messageQueue.Add(msg);
        }

        private void SndToConnection()
        {
            while (TcpConnection != null && TcpConnection.Connected)
            {
                if (messageQueue.Count > 0)
                {
                    Message msg = messageQueue[0];
                    try
                    {
                        //lock(sync)
                        //{
                        StreamWriter sw = new StreamWriter(TcpConnection.GetStream());
                        sw.WriteLine(msg);
                        sw.Flush();
                        //sw.Close();
                        //}
                    }
                    catch
                    {
                        TcpConnectionClose(TcpConnection);
                    }
                    finally
                    {
                        messageQueue.Remove(msg);
                    }
                }
                Thread.Sleep(30);
            }
        }

        private void RcvFromConnection()
        {
            while (TcpConnection != null && TcpConnection.Connected)
            {
                if (TcpConnection.Available > 0)
                {
                    try
                    {
                        string rcvMsg = string.Empty;
                        //lock (sync)
                        //{

                        StreamReader sr = new StreamReader(TcpConnection.GetStream());
                        rcvMsg = sr.ReadLine();
                        //sr.Close();
                        //}
                        string[] msg = rcvMsg.Split('#');
                        Message msg1 = new Message { From = msg[0], To = msg[1], Text = msg[2] };

                        if (msg1.To == "$ALL")//send to all online users
                        {
                            var lst = Context.Connections.Where(c => c.Value.TcpConnection.Connected).Select(c1 => c1.Value).ToList();
                            if (lst != null)
                                foreach (var item in lst)
                                {
                                    item.Add(msg1);
                                }
                        }
                        else if (msg1.To == msg1.From && msg1.Text == msg1.To && msg1.To == "$BYE")
                        {
                            TcpConnectionClose(TcpConnection);
                            SendOnlineListForAllOnlineUser();
                        }
                        else if (msg1.To == msg1.From && msg1.Text == "$LIST")
                        {
                            Message myMsg=List();
                            Add(myMsg);

                        }
                        else//send from p1 to somebody
                        {
                            var user = Context.Users.Where(u => u.Key == msg1.To && u.Value.LoginStatus).Select(u => u.Value).ToList();
                            if (user != null)
                                foreach (var u in user)
                                {
                                    var lst = u.Connections.ToList();
                                    if (lst != null)
                                        foreach (var item in lst)
                                        {
                                            item.Add(msg1);
                                        }
                                }

                        }


                    }//end try
                    catch
                    {

                    }//end catch
                }//end if
                Thread.Sleep(30);
            }//end while
        }

        public static void SendOnlineListForAllOnlineUser()
        {
            Message myMsg = List();
            var conns = Context.Connections.Where(c => c.Value.TcpConnection.Connected).ToList();
            foreach (var c in conns)
            {
                c.Value.Add(myMsg);
            }
        }

        //list online user
        public static Message List()
        {
            Message msg1=new Message();
            var user = Context.Users.Where(u => u.Value.Connections.FirstOrDefault(f => f.TcpConnection.Connected) != null).Select(u => u.Value).ToList();
            string m = string.Empty;
            if (user != null)
                for (int i = 0; i < user.Count; i++)
                {
                    if (i != user.Count - 1)
                    {
                        m += user[i].Username + "@";
                    }
                    else
                    {
                        m += user[i].Username;
                    }
                }
            msg1.To = " ";
            msg1.From = "$LIST";
            msg1.Text = m;
            return msg1;
        }

        public void TcpConnectionClose(TcpClient TcpConnection)
        {
            if (TcpConnection != null)
            {
                Connection conn = null;
                Context.Connections.TryRemove(ConnectionId, out conn);
                if (conn != null)
                {
                    var user = Context.Users.FirstOrDefault(f => f.Value.Connections.FirstOrDefault(c => c.ConnectionId == conn.ConnectionId) != null);
                    try
                    {
                        user.Value.Connections.Remove(conn);
                        if (user.Value.Connections.Count == 0)
                            user.Value.LoginStatus = false;
                    }
                    catch { }
                }

                TcpConnection.Close();
                TcpConnection = null;
            }
        }
    }

    public struct Message
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return string.Format($"{From}#{To}#{Text}");
        }
    }
}
