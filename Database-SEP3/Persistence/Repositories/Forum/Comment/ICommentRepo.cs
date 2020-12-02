using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Comment;

namespace Database_SEP3.Persistence.Repositories.Comment
{
    public interface ICommentRepo
    {
        public Task<CommentList> GetCommentsFromPost(int postId);
        public Task CreateComment(CommentModel commentModel, int postId);
    }
}