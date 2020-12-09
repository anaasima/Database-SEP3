using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Model.Rating;
using Database_SEP3.Persistence.Repositories.Forum.Comment;
using Database_SEP3.Persistence.Repositories.Forum.Post;

namespace Database_SEP3.Networking.Forum
{
    public class Server_ForumHandler
    {
        private IPostRepo _postRepo;
        private ICommentRepo _commentRepo;
        private IList<PostModel> _postList;
        private IList<CommentModel> _commentList;

        public Server_ForumHandler()
        {
            _postRepo = new PostRepo();
            _commentRepo = new CommentRepo();
            _postList = new List<PostModel>();
            _commentList = new List<CommentModel>();
        }

        public async void ReadAllPosts(NetworkStream stream)
        {
            _postList = await _postRepo.GetAllPosts();
            string reply = JsonSerializer.Serialize(_postList);
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
            await _postRepo.GiveRating(ratingPostModel);
        }

        public async void AddComment(string content)
        {
            CommentModel commentModel = JsonSerializer.Deserialize<CommentModel>(content);
            await _postRepo.AddComent(commentModel);
        }

        public async void SavePost(string content)
        {
            PostModel postModel = JsonSerializer.Deserialize<PostModel>(content);
            await _postRepo.SavePost(postModel);
        }

        public async void DeletePost(string content)
        {
            PostModel postModel = JsonSerializer.Deserialize<PostModel>(content);
            await _postRepo.DeletePost(postModel);
        }

        public async void Report(string content)
        {
            ReportModel reportModel = JsonSerializer.Deserialize<ReportModel>(content);
            await _postRepo.Report(reportModel);
        }
}
}