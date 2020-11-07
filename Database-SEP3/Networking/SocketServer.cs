using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Database_SEP3.DAO.ComponentsDAO;

namespace Database_SEP3.Networking
{
    public class SocketServer
    {
        private ComponentsDAO _componentsDao;
        private static List<TcpClient> connectedClients;

        public SocketServer()
        {
            _componentsDao = ComponentsDAOImpl.GetInstance();
            connectedClients = new List<TcpClient>();
        }

        public void StartServer()
        {
            Console.WriteLine("Starting server...");

            IPAddress ip = IPAddress.Parse("localhost");
            TcpListener tcpListener = new TcpListener(ip, 2910);
            tcpListener.Start();
            
            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                connectedClients.Add(tcpClient);
                Console.WriteLine("Client connected");

                new Thread(() => Handler(tcpClient)).Start();
            }
            
            
            // try
            // {
            //     TcpListener server = new TcpListener(IPAddress.Any, 2910);
            //     while(true)
            //     {
            //         TcpClient client = server.AcceptTcpClient();
            //         NetworkStream networkStream = client.GetStream();
            //     }
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     throw;
            // }
        }
        public static void Handler(TcpClient tcpClient)
        {
            while (true)
            {
                NetworkStream stream = tcpClient.GetStream();
                //read
                byte[] data = new byte[1024];
                int bytesRead = stream.Read(data, 0, data.Length);
                string s = Encoding.ASCII.GetString(data, 0, bytesRead);
                Console.WriteLine(s);
                if(s.Equals("Exit"))
                    break;

                //respond
                for (int i = 0; i < connectedClients.Count; i++)
                {
                    var clientStream = connectedClients[i].GetStream();
                    byte[] dataToClient = Encoding.ASCII.GetBytes($"Returning {s}"); 
                    clientStream.Write(dataToClient, 0, dataToClient.Length);
                }
                    
                
            }
        }
        

    }
}