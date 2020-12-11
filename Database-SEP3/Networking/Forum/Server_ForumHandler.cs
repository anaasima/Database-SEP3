using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Forum.Report;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Model.Rating;
using Database_SEP3.Persistence.Repositories.Forum.Comment;
using Database_SEP3.Persistence.Repositories.Forum.Post;
using Database_SEP3.Persistence.Repositories.Forum.Report;
using Database_SEP3.Persistence.Repositories.Rating;

namespace Database_SEP3.Networking.Forum
{
    public class Server_ForumHandler
    {
        private IPostRepo _postRepo;
        private ICommentRepo _commentRepo;
        private IList<PostModel> _postList;
        private IList<CommentModel> _commentList;
        private IRatingRepo _ratingRepo;
        private IReportRepo _reportRepo;
        private IList<ReportModel> _reportModels;
        
        public Server_ForumHandler()
        {
            _postRepo = new PostRepo();
            _commentRepo = new CommentRepo();
            _postList = new List<PostModel>();
            _commentList = new List<CommentModel>();
            _ratingRepo = new RatingRepo();
            _reportRepo = new ReportRepo();
            _reportModels = new List<ReportModel>();
        }

        public async void ReadAllPosts(NetworkStream stream)
        {
            _postList = await _postRepo.GetAllPosts();
            string reply = JsonSerializer.Serialize(_postList);
            Console.WriteLine("yey  " + reply);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void AddPost(string content)
        {
            PostModel postModel = JsonSerializer.Deserialize<PostModel>(content);
            await _postRepo.CreatePost(postModel);
        }

        public async void GiveRating(string content)
        {
            RatingPostModel ratingPostModel = JsonSerializer.Deserialize<RatingPostModel>(content);
            await _ratingRepo.CreatePostRating(ratingPostModel);
        }

        public async void AddComment(string content)
        {
            CommentModel commentModel = JsonSerializer.Deserialize<CommentModel>(content);
            await _commentRepo.CreateComment(commentModel);
        }

        public async void SavePost(string content)
        {
            string[] substrings = content.Split('*');
            PostModel postModel = JsonSerializer.Deserialize<PostModel>(substrings[0]);
            int userId = Int32.Parse(substrings[1]);
            await _postRepo.SavePost(postModel, userId);
        }
        
        public async void DeletePost(string content)
        {
            int userId = Int32.Parse(content);
            await _postRepo.DeletePost(userId);
        }

        public async void Report(string content)
        {
            ReportModel reportModel = JsonSerializer.Deserialize<ReportModel>(content);
            await _reportRepo.CreateReport(reportModel);
        }

        public async void DeleteReport(string content)
        {
            await _reportRepo.DeleteReport(Int32.Parse(content));
        }

        public async void GetAllReports(NetworkStream stream)
        {
            _reportModels = await _reportRepo.ReadAllReports();
            string reply = JsonSerializer.Serialize(_reportModels);
            
            
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void GetAllPostRatings(NetworkStream stream, string content)
        {
            IList<RatingPostModel> ratingPostModels = await _ratingRepo.GetAllPostRatings(Int32.Parse(content));
            string reply = JsonSerializer.Serialize(ratingPostModels);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
        
        public async void GetAllBuildRatings(NetworkStream stream, string content)
        {
            IList<RatingBuildModel> ratingBuildModels = await _ratingRepo.GetAllBuildRatings(Int32.Parse(content));
            string reply = JsonSerializer.Serialize(ratingBuildModels);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
        
        public async void GetAllComponentRatings(NetworkStream stream, string content)
        {
            IList<RatingComponentModel> ratingComponentModels = await _ratingRepo.GetAllComponentRatings(Int32.Parse(content));
            string reply = JsonSerializer.Serialize(ratingComponentModels);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void EditPost(string req1Content)
        {
            PostModel postModel = JsonSerializer.Deserialize<PostModel>(req1Content);
            await _postRepo.EditPost(postModel);
        }

        public async void GetPostsByUserId(NetworkStream stream, string req1Content)
        {
            IList<PostModel> postModels = await _postRepo.GetPostsFromAccount(Int32.Parse(req1Content));
            string reply = JsonSerializer.Serialize(postModels);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void GetSavedPosts(NetworkStream stream, string req1Content)
        {
            IList<PostModel> postModels = await _postRepo.GetSavedPosts(Int32.Parse(req1Content));
            string reply = JsonSerializer.Serialize(postModels);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
    }
}