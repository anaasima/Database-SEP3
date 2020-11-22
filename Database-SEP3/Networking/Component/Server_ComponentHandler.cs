using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Repositories;

namespace Database_SEP3.Networking.Component
{
    public class Server_ComponentHandler
    {
        private ComponentList _componentList;
        private ComponentRepo _componentRepo;

        public Server_ComponentHandler()
        {
            _componentList = new ComponentList();
            _componentRepo = new ComponentRepo();
        }

        public async void ReadAllComponents(NetworkStream stream)
        {
            _componentList = await _componentRepo.ReadComponents();
            
            string reply = JsonSerializer.Serialize(_componentList);
            Console.WriteLine(reply);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
    }
}