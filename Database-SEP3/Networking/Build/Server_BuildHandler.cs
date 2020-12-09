using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Rating;
using Database_SEP3.Persistence.Repositories.Build;
using Database_SEP3.Persistence.Repositories.Component;
using Database_SEP3.Persistence.Repositories.Rating;

namespace Database_SEP3.Networking.Build
{
    public class Server_BuildHandler
    {
        private IList<BuildModel> _buildList;
        private IBuildRepo _buildRepo;
        private ComponentRepo _componentRepo;
        private IRatingRepo _ratingRepo;

        public Server_BuildHandler()
        {
            _buildList = new List<BuildModel>();
            _buildRepo = new BuildRepo();
            _componentRepo = new ComponentRepo();
            _ratingRepo = new RatingRepo();
        }

        public async void ReadAllBuilds(NetworkStream stream, string content)
        {
            _buildList = await _buildRepo.GetBuildsFromAccount(Int32.Parse(content));       
            for (int i = 0; i < _buildList.Count(); i++)
            {
                _buildList[i].ComponentList = await _componentRepo.GetComponentsFromBuild(_buildList[i].Id);
            }

            string reply = JsonSerializer.Serialize(_buildList);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void AddBuild(string content)
        {
            BuildModel buildModel = JsonSerializer.Deserialize<BuildModel>(content);
            await _buildRepo.CreateBuild(buildModel);
        }

        public async void EditBuild(string content)
        {
            BuildModel buildModel = JsonSerializer.Deserialize<BuildModel>(content);
            await _buildRepo.EditBuild(buildModel);
        }

        public async void DeleteBuild(string content)
        {
            int id = Int32.Parse(content);
            await _buildRepo.DeleteBuild(id);
        }

        public async void GiveRating(string content)
        {
            RatingBuildModel ratingBuildModel = JsonSerializer.Deserialize<RatingBuildModel>(content);
            await _ratingRepo.CreateBuildRating(ratingBuildModel);
        }
    }
}