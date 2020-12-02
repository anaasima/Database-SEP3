using System;
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

        public async Task<CommentList> GetCommentsFromPost(int postId)
        {
            await using (_context = new Sep3DBContext())
            {
                PostModel account = await _context.Posts
                    .Include(p => p.Comments)
                    .FirstAsync(post => post.Id == postId);
                Console.WriteLine(account.ToString() + " took from database to get comments from");
                CommentList commentList = new CommentList();
                foreach (var comment in account.Comments)
                {
                    commentList.AddComment(comment);
                    Console.WriteLine(comment.ToString());
                }

                return commentList;
            }
        }

        public async Task CreateComment(CommentModel commentModel, int postId)
        {
            await using (_context = new Sep3DBContext())
            {
                await _context.Comments.AddAsync(commentModel);
                await _context.SaveChangesAsync();
                PostModel postModel = await _context.Posts
                    .Include(p => p.Comments)
                    .FirstAsync(post => post.Id == postId);
                CommentModel commentDatabase = await _context.Comments.FirstAsync(c => c.Id == commentModel.Id);
                postModel.Comments.Add(commentDatabase);
                _context.Posts.Update(postModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}