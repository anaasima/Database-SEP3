using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database_SEP3.Networking;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Component;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Repositories;
using Database_SEP3.Persistence.Repositories.Account;
using Database_SEP3.Persistence.Repositories.Build;
using Database_SEP3.Persistence.Repositories.Forum.Comment;
using Database_SEP3.Persistence.Repositories.Component;
using Database_SEP3.Persistence.Repositories.Forum.Post;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SocketServer socketServer = new SocketServer();
            socketServer.StartServer();

            // await using (Sep3DBContext context = new Sep3DBContext())
            // {
            //     CommentModel cm = await context.Comments.FirstAsync(c => c.Id == 1);
            //     Console.WriteLine(cm.ToString());
            //     PostModel pm = await context.Posts.FirstAsync(p => p.Id == 2);
            //     Console.WriteLine(pm.CommentList.ToString());
            //     if (pm.CommentList == null)
            //     {
            //         pm.CommentList = new CommentList();
            //     }
            //     pm.CommentList.AddComment(cm);
            //     context.Posts.Update(pm);
            //     await context.SaveChangesAsync();
            // }
            // ICommentRepo _commentRepo = new CommentRepo();
            // CommentModel commentModel = new CommentModel
            // {
            //     Id = 0,
            //     Content = "Yeet",
            //     DownVote = 0,
            //     UpVote = 0
            // };
            //
            // await _commentRepo.CreateComment(commentModel, 2,1);


            //
            // IPostRepo postRepo = new PostRepo();
            // PostModel postModel = new PostModel
            // {
            //     Content = "Ana are meme",
            //     DownVote = 0,
            //     UpVote = 0,
            // };
            //
            // await postRepo.CreatePost(postModel, 3);

            // CommentRepo commentRepo = new CommentRepo();
            // PostRepo postRepo = new PostRepo();
            // AccountRepo accountRepo = new AccountRepo();
            // ComponentRepo componentRepo = new ComponentRepo();
            // BuildRepo buildRepo = new BuildRepo();
            // ComponentModel c1 = new ComponentModel  //TODO: this will later woosh
            // {
            //     Id = 2,
            //     Type = "CPU",
            //     Name = "Intel i5",
            //     Brand = "Gigabyte",
            //     ReleaseYear = "2019",
            //     AdditionalInfo = "sdf"
            // };
            // ComponentModel c2 = new ComponentModel  //TODO: this will later woosh
            // {
            //     Id = 3,
            //     Type = "BLABLA",
            //     Name = "Intel i5",
            //     Brand = "Gigabyte",
            //     ReleaseYear = "2019",
            //     AdditionalInfo = "sdf"
            // };
            // await componentRepo.CreateComponent(c1);
            // await componentRepo.CreateComponent(c2);
            // AccountModel accountModel = new AccountModel
            // {
            //     UserId = 2,
            //     Name = "bonk",
            //     Password = "98765",
            //     Username = "MiauMiau",
            // };
            // await accountRepo.UpdateAccount(accountModel);
            // await accountRepo.CreateAccount(accountModel);

            // ComponentList componentList =new ComponentList();
            // componentList.AddComponent(c1);
            // componentList.AddComponent(c2);
            // BuildModel buildModel = new BuildModel()
            // {
            //     Name = "test1",
            // };
            // await buildRepo.CreateBuild(buildModel, componentList, 1);

            // await componentRepo.GetComponentsFromBuild(3);
            // await buildRepo.GetBuildsFromAccount(1);
            // await accountRepo.DeleteAccount(1);
            // await accountRepo.CreateAccount(accountModel);
            //
            // PostModel postModel = new PostModel
            // {
            //     UpVote = 10,
            //     DownVote = 3,
            //     Content = "adasdasda"
            // };
            // await postRepo.CreatePost(postModel,2);
            //
            // CommentModel com1 = new CommentModel
            // {
            //     UpVote = 14,
            //     DownVote = 1,
            //     Content = "adasdasda"
            // };
            // CommentModel com2 = new CommentModel
            // {
            //     UpVote = 8,
            //     DownVote = 3,
            //     Content = "adasdasda"
            // };

            // await commentRepo.GetCommentsFromPost(1);

            // await postRepo.GetPostsFromAccount(2);

            // await commentRepo.CreateComment(com1,1);
            // await commentRepo.CreateComment(com2,1);
            // ComponentList componentList =  await componentRepo.ReadComponents();

            // await accountRepo.CreateAccount(accountModel);
            // Thread.Sleep(1000);
            //
            // ComponentModel c1 = new ComponentModel
            // {
            //     Id = 2
            // };
            // ComponentModel c2 = new ComponentModel
            // {
            //     Id = 3
            // };
            // List<ComponentModel> componentModels = new List<ComponentModel>();
            // componentModels.Add(c1);
            // componentModels.Add(c2);
            // // await componentRepo.GetComponentsFromBuild(1);
            //
            // // await buildRepo.ReadBuilds(3);
            // Console.WriteLine(componentModels.Count);
            // await buildRepo.CreateBuild(buildModel, componentModels);
            //
            // BuildList list = await buildRepo.ReadBuilds(0);
            // Console.WriteLine(list);
            // Thread.Sleep(1000);
            // for (int i = 0; i < list.Size(); i++)
            // {
            //     Console.WriteLine(list.Get(1).Id);
            //     ComponentList dummyList = await componentRepo.GetComponentsFromBuild(list.Get(1).Id);
            //     Console.WriteLine(dummyList.ToString());
            // }
            // Thread.Sleep(1000);
            // Console.WriteLine(list.Get(0) + "\n" + list.Get(1));
            // Console.WriteLine(list.Get(1).BuildComponents[1] );


            // await buildRepo.CreateBuild(buildModel, componentModels);
            //Clase diferite in tier 1 si tier 2, slideurile lui Troels; Build sa aiba lista de Componente si Component lista de Builds,
            //in loc de BuildComponents; Probleme networking la castare?
            //lista de componentId ca parametru la CreateBuild



            // await accountRepo.CreateAccount(accountModel);
            // await repo.RemoveComponentFromBuild(1, 2);
            // await repo.AddComponentToBuild(1, 2);

            // SocketServer socketServer = new SocketServer();
            // socketServer.StartServer();
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
            //
            // IList<BuildModel> list = context.Builds.ToList();
            // await accountRepo.AddBuilds(list, 1);
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