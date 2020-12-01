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
        private IBuildRepo _buildRepo;
        private ComponentRepo _componentRepo;

        public Server_BuildHandler()
        {
            _buildList = new BuildList();
            _buildRepo = new BuildRepo();
            _componentRepo = new ComponentRepo();
        }

        public async void ReadAllBuilds(NetworkStream stream, String content)
        {
            _buildList = await _buildRepo.ReadBuilds(Int32.Parse(content));        //Remember that for the first test in Sprint 3, we changed the content (id) by hand in database, from 0 to 1 (1 being the id of a user)
            for (int i = 0; i < _buildList.Size(); i++)
            {
                _buildList.Builds[i].ComponentList = await _componentRepo.GetComponentsFromBuild(_buildList.Get(i).Id);
            }
            string reply = JsonSerializer.Serialize(_buildList);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
    }
}