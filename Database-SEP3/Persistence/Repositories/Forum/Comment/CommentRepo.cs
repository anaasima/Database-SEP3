using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Repositories.Forum.Comment;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Forum.Comment
{
    public class CommentRepo : ICommentRepo
    {
        
        private Sep3DBContext _context;

        public async Task<IList<CommentModel>> GetCommentsFromPost(int postId)
        {
            await using (_context = new Sep3DBContext())
            {
                PostModel post = await _context.Posts
                    .Include(p => p.Comments)
                    .FirstAsync(pst => pst.Id == postId);
                Console.WriteLine(post.ToString() + " took post from database to get comments from");
                IList<CommentModel> commentList = new List<CommentModel>();
                foreach (var comment in post.Comments)
                {
                    commentList.Add(comment);
                    Console.WriteLine(comment.ToString());
                }

                return commentList;
            }
        }

        public async Task CreateComment(CommentModel commentModel)
        {
            await using (_context = new Sep3DBContext())
            {
                await _context.Comments.AddAsync(commentModel);
                AccountModel accountModel = await _context.Accounts
                    .Include(acc => acc.Comments)
                    .FirstAsync(a => a.UserId == commentModel.AccountModelUserId);
                accountModel.Comments.Add(commentModel);
                _context.Accounts.Update(accountModel);
                PostModel postModel = await _context.Posts
                    .Include(p => p.Comments)
                    .FirstAsync(post => post.Id == commentModel.PostModelId);
                postModel.Comments.Add(commentModel);
                // postModel.CommentList.Add(commentModel);
                _context.Posts.Update(postModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}