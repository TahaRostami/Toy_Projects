using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tataiee.IEP.ServerApplication
{
    public class Program
    {
        bool running;
        TcpListener tcpListener;
        public static void Main(string[] args)
        {
            Program program = new Program();
        }//end method Main

        public Program()
        {
            try
            {
                tcpListener = new TcpListener(new System.Net.IPEndPoint(IPAddress.Any, 2018));
                tcpListener.Start();
                running = true;
                Running();
            }//end try
            catch (Exception ex)
            {

            }//end catch

        }//end Program constructor

        private void Running()
        {
            try
            {
                while (running)
                {
                    TcpClient newClient = tcpListener.AcceptTcpClient();
                    Thread newClientProcessor = new Thread(ManageNewClient) { IsBackground = true };
                    newClientProcessor.Start(newClient);
                }
            }
            catch
            {

            }
            finally
            {
                running = false;
            }
        }//end method Running

        private void ManageNewClient(object c)
        {
            TcpClient client = c as TcpClient;
            if (client == null) return;
            try
            {
                Connection newConnection = new Connection(this, client);

                NetworkStream ns = client.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);

                string cmd = sr.ReadLine();
                string username = sr.ReadLine();
                string password = sr.ReadLine();
                User user;
                Context.Users.TryGetValue(username, out user);
                if (cmd == "LOGIN" && user != null && user.Password == password)//user can login with the use of different devices or multiple instances
                {
                    user.LoginStatus = true;

                    sw.WriteLine("LOGIN_OK");
                    sw.WriteLine(newConnection.ConnectionId);
                    sw.Flush();

                    Context.Connections.TryAdd(newConnection.ConnectionId, newConnection);
                    user.AddConnection(newConnection);

                    newConnection.Start();
                }
                else if (cmd == "REGISTER" && user == null && !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password) && username.Length >= 4 && username.Length < 12 && password.Length >= 6 && password.Length < 16)
                {

                    sw.WriteLine("OK_REGISTER_AND_LOGIN");
                    sw.WriteLine(newConnection.ConnectionId);
                    sw.Flush();

                    Context.Connections.TryAdd(newConnection.ConnectionId, newConnection);

                    User newUser = new User()
                    {
                        LoginStatus = true,
                        Password = password,
                        Username = username,
                    };
                    newUser.AddConnection(newConnection);

                    Context.Users.TryAdd(newUser.Username, newUser);
                    newConnection.Start();
                }
                else
                {
                    sw.WriteLine("FAILED");
                    sw.WriteLine(" ");
                    sw.Flush();
                    if (client != null)
                        client.Close();
                }

            }
            catch
            {
            }
        }

        private void Shutdown()
        {
            running = false;
            if (tcpListener != null)
                tcpListener.Stop();
        }
    }
}
