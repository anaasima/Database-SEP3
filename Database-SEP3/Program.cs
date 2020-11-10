using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Networking;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Repositories;

namespace Database_SEP3
{
    class Program
    {
        static void Main(string[] args)
        {
            // ComponentRepo c1 = new ComponentRepo();
            // c1.createComponent();
            // List<Component> list = c1.readComponent().Result.ToList();
            // foreach (var component in list)
            // {
            //    Console.WriteLine(component.ToString());
            // }
            
            SocketServer socketServer = new SocketServer();
            socketServer.StartServer();
        }
    }
}