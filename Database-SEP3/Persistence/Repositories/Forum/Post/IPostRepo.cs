using System.Threading.Tasks;
using Database_SEP3.Persistence.Model.Post;

namespace Database_SEP3.Persistence.Repositories.Forum.Post
{
    public interface IPostRepo
    {
        Task<PostList> GetAllPosts();
         Task<PostModel> GetPost(int postId);
         Task<PostList> GetPostsFromAccount(int userId);
         Task CreatePost(PostModel postModel, int userid);
    }
}