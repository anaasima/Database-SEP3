using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Comment;

namespace Database_SEP3.Persistence.Repositories.Forum.Comment
{
    public interface ICommentRepo        //dunno why they gray
    {
        Task<IList<CommentModel>> GetCommentsFromPost(int postId);
        Task CreateComment(CommentModel commentModel);
    }
}