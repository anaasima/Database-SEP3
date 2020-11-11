using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Database_SEP3.Networking.Util;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Repositories;
using Component = System.ComponentModel.Component;

namespace Database_SEP3.Networking
{
    public class SocketServer
    {
        private IComponentRepo _componentRepo;
        private static List<TcpClient> connectedClients;
        private ComponentList componentList;

        public SocketServer()
        {
            connectedClients = new List<TcpClient>();
            _componentRepo = new ComponentRepo();
            componentList = new ComponentList();
        }

        public void StartServer()
        {
            Console.WriteLine("Starting server...");
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 2910);
            tcpListener.Start();

            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                connectedClients.Add(tcpClient);
                Console.WriteLine("Client connected");

                new Thread(() => Handler(tcpClient)).Start();
            }
        }
        

        public void Handler(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();

            while (true)
            {
                try
                {
                    byte[] data = new byte[64 * 1024];
                    int bytesToRead = stream.Read(data, 0, data.Length);
                    string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
                    Console.WriteLine(req);
                    switch (req)
                    {
                        case "\"COMPONENTS\"":
                            ReadComponentFromDatabase(stream);
                            break;
                    }
                }
                catch (IOException e)
                {
                    connectedClients.Remove(tcpClient);
                }
            }
        }


        private async void ReadComponentFromDatabase(NetworkStream stream)
        {
            componentList = await _componentRepo.readComponents();

            string reply = JsonSerializer.Serialize(componentList);
            Console.WriteLine(reply);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
    }
}