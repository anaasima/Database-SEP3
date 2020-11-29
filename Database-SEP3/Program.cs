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
            BuildRepo repo = new BuildRepo();
            await repo.RemoveComponentFromBuild(1, 2);
            await repo.AddComponentToBuild(1, 2);
                
            SocketServer socketServer = new SocketServer();
            socketServer.StartServer();
            // ComponentRepo c1 = new ComponentRepo();
            // c1.CreateComponent();
            // List<Component> list = c1.readComponent().Result.ToList();
            // foreach (var component in list)
            // {
            //    Console.WriteLine(component.ToString());
            // }
            // Sep3DBContext context = new Sep3DBContext();
            // BuildModel buildModel = await context.Builds.FirstAsync(b => b.Id == 1);
            // ComponentModel componentModel = await context.Components.FirstAsync(c => c.Id == 2);
            // BuildComponent buildComponent = new BuildComponent()
            // {
            //     BuildModel = buildModel,
            //     ComponentModel = componentModel
            // };
            // buildModel.BuildComponents = new List<BuildComponent>();
            // buildModel.BuildComponents.Add(buildComponent);
            // context.Update(buildModel);
            // await context.SaveChangesAsync();

            // AccountModel accountModel = await context.Accounts.FirstAsync(a => a.UserId == 3);
            // BuildModel buildModel = await context.Builds.FirstAsync(b => b.Id == 1);
            // accountModel.Builds = new List<BuildModel>();
            // accountModel.Builds.Add(buildModel);
            // context.Update(accountModel);
            // await context.SaveChangesAsync();


            // AccountRepo _accountRepo = new AccountRepo();
            // ComponentRepo componentRepo = new ComponentRepo();
            // BuildRepo buildRepo = new BuildRepo();
            //
            // AccountModel accountModel = new AccountModel();
            // accountModel.UserId = 1;
            // accountModel.Username = "asasas";
            // accountModel.Password = "123";
            // accountModel.Name = "BOB";
            //


            //
            // // ComponentModel component = context.Components.First(c => c.Id == 1);
            // // Console.WriteLine(component.ToString());
            //
            // //accountModel.Builds.Add(buildModel);
            // // _accountRepo.CreateAccount(accountModel);
            // await context.Builds.AddAsync(buildModel);
            // await context.SaveChangesAsync();
        }
    }
}