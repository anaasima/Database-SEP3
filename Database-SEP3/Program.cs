using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Networking;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Repositories;
using Database_SEP3.Persistence.Repositories.Build;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // ComponentRepo c1 = new ComponentRepo();
            // c1.createComponent();
            // List<Component> list = c1.readComponent().Result.ToList();
            // foreach (var component in list)
            // {
            //    Console.WriteLine(component.ToString());
            // }
            
            // SocketServer socketServer = new SocketServer();
            // socketServer.StartServer();
            
            Sep3DBContext context = new Sep3DBContext();
            AccountRepo _accountRepo = new AccountRepo();
            ComponentRepo componentRepo = new ComponentRepo();
            BuildRepo buildRepo = new BuildRepo();
            
            AccountModel accountModel = new AccountModel();
            accountModel.UserId = 1;
            accountModel.Username = "asasas";
            accountModel.Password = "123";
            accountModel.Name = "BOB";

            BuildModel buildModel = new BuildModel();
            buildModel.Id = 1;
            buildModel.Name = "firstbuild";

            ComponentModel component = context.Components.First(c => c.Id == 1);
            Console.WriteLine(component.ToString());
            
            //accountModel.Builds.Add(buildModel);
            _accountRepo.createAccount(accountModel);
            await context.Builds.AddAsync(buildModel);

        }
    }
}