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
        private Sep3DBContext _context;

        public async Task<IList<PostModel>> GetAllPosts()
        {
            await using (_context = new Sep3DBContext())
            {
                List<PostModel> posts = await _context.Posts.Include(p => p.Comments).ToListAsync();
                return posts;
            }
        }

        public async Task<PostModel> GetPost(int postId)
        {
            await using (_context = new Sep3DBContext())
            {
                return await _context.Posts
                    .Include(post => post.Comments)
                    .FirstAsync(p => p.Id == postId);
            }
        }

        public async Task<IList<PostModel>> GetPostsFromAccount(int userId)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel account = _context.Accounts.Include(acc => acc.Posts).First(a => a.UserId ==
                    userId);
                Console.WriteLine(account + " took from database to get posts from");
                IList<PostModel> postList = new List<PostModel>();
                foreach (var post in account.Posts)
                {
                    postList.Add(post);
                    Console.WriteLine(post.ToString());
                }
                return postList;
            }
        }

        public async Task CreatePost(PostModel postModel)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModel = await _context.Accounts
                    .Include(acc => acc.Posts)
                    .FirstAsync(a => a.UserId == postModel.AccountModelUserId);
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