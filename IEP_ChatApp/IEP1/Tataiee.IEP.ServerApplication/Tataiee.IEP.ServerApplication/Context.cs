using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tataiee.IEP.ServerApplication
{
    public class Context
    {

        public static readonly ConcurrentDictionary<string, Connection> Connections = new ConcurrentDictionary<string, Connection>();//connectionId,Connection
        public static readonly ConcurrentDictionary<string, User> Users = new ConcurrentDictionary<string, User>();//username,User
    }
}
