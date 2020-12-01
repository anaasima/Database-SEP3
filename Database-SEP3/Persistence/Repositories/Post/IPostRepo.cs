using System.Threading.Tasks;
using Database_SEP3.Persistence.Model.Post;

namespace Database_SEP3.Persistence.Repositories.Post
{
    public interface IPostRepo
    {
        public Task<PostModel> GetPost(int postId);
        public Task<PostList> GetPostsFromAccount(int userId);
        public Task CreatePost(PostModel postModel, int userid);
    }
}