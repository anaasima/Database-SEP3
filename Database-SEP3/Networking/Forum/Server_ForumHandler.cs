using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Post;
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
    }
}