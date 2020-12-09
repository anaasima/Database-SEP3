using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Rating;
using Database_SEP3.Persistence.Repositories;
using Database_SEP3.Persistence.Repositories.Component;
using Database_SEP3.Persistence.Repositories.Rating;

namespace Database_SEP3.Networking.Component
{
    public class Server_ComponentHandler
    {
        private IList<ComponentModel> _componentList;
        private IComponentRepo _componentRepo;
        private IRatingRepo _ratingRepo;

        public Server_ComponentHandler()
        {
            _componentList = new List<ComponentModel>();
            _componentRepo = new ComponentRepo();
            _ratingRepo = new RatingRepo();
        }

        public async void ReadAllComponents(NetworkStream stream)
        {
            _componentList = await _componentRepo.ReadComponents();
            string reply = JsonSerializer.Serialize(_componentList);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void Add(string content)
        {
            ComponentModel dummy = JsonSerializer.Deserialize<ComponentModel>(content);
            await _componentRepo.CreateComponent(dummy);
        }

        public async void GiveRating(string content)
        {
            RatingComponentModel ratingComponentModel = JsonSerializer.Deserialize<RatingComponentModel>(content);
            await _ratingRepo.CreateComponentRating(ratingComponentModel);
        }
    }
}