using System;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;
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
                foreach (var variable in _context.Posts)
                {
                    _postList.AddPost(variable);
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
                await _context.Posts.AddAsync(postModel);
                await _context.SaveChangesAsync();
                AccountModel accountModel = await _context.Accounts
                    .Include(acc => acc.Posts)
                    .FirstAsync(a => a.UserId == userid);
                PostModel postDatabase = await _context.Posts.FirstAsync(p => p.Id == postModel.Id);
                accountModel.Posts.Add(postDatabase);
                _context.Accounts.Update(accountModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}