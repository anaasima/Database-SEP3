using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Repositories.Comment;
using Database_SEP3.Persistence.Repositories.Post;

namespace Database_SEP3.Networking.Forum
{
    public class Server_ForumHandler
    {
        private IPostRepo _postRepo;
        private ICommentRepo _commentRepo;
        private PostList _postList;
        private CommentList _commentList;

        public Server_ForumHandler()
        {
            _postRepo = new PostRepo();
            _commentRepo = new CommentRepo();
            _postList = new PostList();
            _commentList = new CommentList();
        }

        public async void ReadAllPosts(NetworkStream stream)
        {
            _postList = await _postRepo.GetAllPosts();
            string reply = JsonSerializer.Serialize(_postList);

            Console.WriteLine(reply);
            
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
    }
}