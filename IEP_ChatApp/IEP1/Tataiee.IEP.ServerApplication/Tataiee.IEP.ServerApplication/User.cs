using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tataiee.IEP.ServerApplication
{
    public class User
    {        
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Connection> Connections = new List<Connection>();
        public bool LoginStatus { get; set; }

        public readonly object sync = new object();
        public void AddConnection(Connection conn)
        {
            lock(sync)
            {
                Connections.Add(conn);
            }
        }
        public void RemoveConnection(Connection conn)
        {
            lock(sync)
            {
                Connections.Remove(conn);
            }
        }

    }
}
