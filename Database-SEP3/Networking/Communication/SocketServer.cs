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
using Database_SEP3.Networking.Account;
using Database_SEP3.Networking.Build;
using Database_SEP3.Networking.Component;
using Database_SEP3.Networking.Forum;
using Database_SEP3.Networking.Util;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Repositories;
using Database_SEP3.Persistence.Repositories.Build;
using Component = System.ComponentModel.Component;


namespace Database_SEP3.Networking       
{
    public class SocketServer
    {
        private static List<TcpClient> _connectedClients;
        private Server_ComponentHandler _componentHandler;
        private Server_BuildHandler _buildHandler;
        private Server_AccountHandler _accountHandler;
        private Server_ForumHandler _forumHandler;
        
        public SocketServer()
        {
            _connectedClients = new List<TcpClient>();
            _componentHandler = new Server_ComponentHandler();
            _buildHandler = new Server_BuildHandler();
            _accountHandler = new Server_AccountHandler();
            _forumHandler = new Server_ForumHandler();
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
                _connectedClients.Add(tcpClient);
                Console.WriteLine("Client connected");

                new Thread(() => Handler(tcpClient)).Start();
            }
        }


        private void Handler(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();

            while (true)
            {
                try
                {
                    byte[] data = new byte[64 * 1024];
                    int bytesToRead = stream.Read(data, 0, data.Length);
                    string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
                    NetworkPackage req1 = JsonSerializer.Deserialize<NetworkPackage>(req);

                    Console.WriteLine(req1.Content);
                    
                    switch (req1.NetworkType)
                    {
                        case "COMPONENTS":
                            _componentHandler.ReadAllComponents(stream);
                            break;
                        case "BUILDS":
                            _buildHandler.ReadAllBuilds(stream, req1.Content);
                            break;
                        case "LOGIN":
                            _accountHandler.GetMyAccount(stream, req1.Content);
                            break;
                        case "REGISTER":
                            _accountHandler.Register(stream, req1.Content);
                            break;
                        case "DELETEACCOUNT":
                            _accountHandler.Delete(req1.Content);
                            break;
                        case "EDITACCOUNT":
                            _accountHandler.Edit(stream, req1.Content);
                            break;
                        case "ADDNEWCOMPONENT":
                            _componentHandler.Add(req1.Content);
                            break;
                        case "POSTS":
                            _forumHandler.ReadAllPosts(stream);
                            break;
                        case "OTHERACCOUNT":
                            _accountHandler.GetAccountByUsername(stream, req1.Content);
                            break;
                        case "ADDPOST":
                            _forumHandler.AddPost(req1.Content);
                            break;
                        case "ADDBUILD":
                            _buildHandler.AddBuild(req1.Content);
                            break;
                        case "EDITBUILD":
                            _buildHandler.EditBuild(req1.Content);
                            break;
                        case "DELETEBUILD":
                            _buildHandler.DeleteBuild(req1.Content);
                            break;
                        case "RATINGBUILDS":
                            _buildHandler.GiveRating(req1.Content);
                            break;
                        case "RATINGCOMPONENTS":
                            _componentHandler.GiveRating(req1.Content);
                            break;
                        case "RATINGPOSTS":
                            _forumHandler.GiveRating(req1.Content);
                            break;
                        case "POSTCOMMENT":
                            _forumHandler.AddComment(req1.Content);
                            break;
                        case "SAVEPOST":
                            _forumHandler.SavePost(req1.Content);
                            break;
                        case "DELETEPOST":
                            _forumHandler.DeletePost(req1.Content);
                            break;
                        case "REPORT":
                            _forumHandler.Report(req1.Content);
                            break;
                        case "DELETEREPORT":
                            _forumHandler.DeleteReport(req1.Content);
                            break;
                        case "REPORTS":
                            _forumHandler.GetAllReports(stream);
                            break;
                        case "POSTRATINGS":
                            _forumHandler.GetAllPostRatings(stream, req1.Content);
                            break;
                        case "BUILDRATINGS":
                            _forumHandler.GetAllBuildRatings(stream, req1.Content);
                            break; 
                        case "COMPONENTRATINGS":
                            _forumHandler.GetAllComponentRatings(stream, req1.Content);
                            break;
                        case "FOLLOWEDACCOUNTS":
                            _accountHandler.GetFollowedAccounts(stream, req1.Content);
                            break;
                        case "FOLLOW":
                            _accountHandler.Follow(req1.Content);
                            break;
                        case "UNFOLLOW":
                            _accountHandler.Unfollow(req1.Content);
                            break;
                        case "GETUSERBYID":
                            _accountHandler.GetUserById(stream, req1.Content);
                            break;
                        case "FILTERLIST":
                            _componentHandler.GetFilteredList(stream, req1.Content);
                            break;
                        case "EDITPOST":
                            _forumHandler.EditPost(req1.Content);
                            break;
                        case "GETPOSTSBYUSERID":
                            _forumHandler.GetPostsByUserId(stream, req1.Content);
                            break;
                        case "GETSAVEDPOSTS":
                            _forumHandler.GetSavedPosts(stream, req1.Content);
                            break;
                        default: 
                            string reply = JsonSerializer.Serialize("conFromTier3");
                            Console.WriteLine("What am i " + reply);
                            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
                            stream.Write(bytesWrite, 0, bytesWrite.Length);
                            break;
                    }
                    stream.Close();
                    break; //will bite you in the ass later, maybe
                }
                catch (IOException e)
                {
                    _connectedClients.Remove(tcpClient);
                }
            }
        }
    }
}