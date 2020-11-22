using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Repositories.Build;

namespace Database_SEP3.Networking.Build
{
    public class Server_BuildHandler
    {
        private BuildList _buildList;
        private BuildRepo _buildRepo;

        public Server_BuildHandler()
        {
            _buildList = new BuildList();
            _buildRepo = new BuildRepo();
        }

        public async void ReadAllBuilds(NetworkStream stream)
        {
            _buildList = await _buildRepo.ReadBuilds();
            
            string reply = JsonSerializer.Serialize(_buildList);
            Console.WriteLine(reply);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
    }
}