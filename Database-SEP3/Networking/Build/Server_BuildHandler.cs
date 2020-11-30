using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Component;
using Database_SEP3.Persistence.Repositories.Build;
using Database_SEP3.Persistence.Repositories.Component;

namespace Database_SEP3.Networking.Build
{
    public class Server_BuildHandler
    {
        private BuildList _buildList;
        private BuildRepo _buildRepo;
        private ComponentRepo _componentRepo;

        public Server_BuildHandler()
        {
            _buildList = new BuildList();
            _buildRepo = new BuildRepo();
            _componentRepo = new ComponentRepo();
        }

        public async void ReadAllBuilds(NetworkStream stream, String content)
        {
            Console.WriteLine("AA" + content);
            _buildList = await _buildRepo.ReadBuilds(Int32.Parse(content)); //TODO: change to variable

            for (int i = 0; i < _buildList.Size(); i++)
            {
                Console.WriteLine(_buildList.Get(i));
                _buildList.Builds[i].ComponentList = await _componentRepo.GetComponentsFromBuild(_buildList.Get(i).Id);
            }

            string reply = JsonSerializer.Serialize(_buildList);
            Console.WriteLine("Build reply" + reply);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
    }
}