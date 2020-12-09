using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model.Post;

namespace Database_SEP3.Persistence.Repositories.Forum.Post
{
    public interface IPostRepo
    {
        Task<IList<PostModel>> GetAllPosts();
         Task<PostModel> GetPost(int postId);
         Task<IList<PostModel>> GetPostsFromAccount(int userId);
         Task CreatePost(PostModel postModel);
         Task SavePost(PostModel postModel, int userId);
         Task DeletePost(int postId);
    }
}