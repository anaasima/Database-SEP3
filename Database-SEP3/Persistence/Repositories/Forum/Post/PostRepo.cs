using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Repositories.Forum.Post;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Forum.Post
{
    public class PostRepo : IPostRepo
    {
        private PostList _postList;
        private Sep3DBContext _context;

        public async Task<PostList> GetAllPosts()
        {
            _postList = new PostList();
            await using (_context = new Sep3DBContext())
            {
                List<PostModel> posts = await _context.Posts.Include(p => p.Comments).ToListAsync();
                foreach (var variable in posts)
                {
                    variable.CommentList = new CommentList();
                    foreach (var comment in variable.Comments)
                    {
                        variable.CommentList.AddComment(comment);
                    }
                    _postList.AddPost(variable);
                    Console.WriteLine("number of comments in post  " + variable.CommentList.Size());
                }
            }

            return _postList;
        }

        public async Task<PostModel> GetPost(int postId)
        {
            await using (_context = new Sep3DBContext())
            {
                return await _context.Posts.FirstAsync(p => p.Id == postId);
            }
        }

        public async Task<PostList> GetPostsFromAccount(int userId)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel account = _context.Accounts.Include(acc => acc.Posts).First(a => a.UserId ==
                    userId);
                Console.WriteLine(account.ToString() + " took from database to get posts from");
                PostList postList = new PostList();
                foreach (var post in account.Posts)
                {
                    postList.AddPost(post);
                    Console.WriteLine(post.ToString());
                }

                return postList;
            }
        }

        public async Task CreatePost(PostModel postModel, int userid)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModel = await _context.Accounts
                    .Include(acc => acc.Posts)
                    .FirstAsync(a => a.UserId == userid);
                postModel.Username = accountModel.Username;
                if (accountModel.Posts == null)
                {
                    accountModel.Posts = new List<PostModel>();
                }
                accountModel.Posts.Add(postModel);
                _context.Accounts.Update(accountModel);
                await _context.Posts.AddAsync(postModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}