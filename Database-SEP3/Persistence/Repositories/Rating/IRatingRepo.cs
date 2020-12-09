using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Model.Rating;

namespace Database_SEP3.Persistence.Repositories.Rating
{
    public interface IRatingRepo
    {
        Task CreateBuildRating(RatingBuildModel ratingBuildModel);
        Task CreatePostRating(RatingPostModel ratingPostModel);
        Task CreateComponentRating(RatingComponentModel ratingComponentModel);
        Task<IList<RatingPostModel>> GetAllPostRatings(int id);
        Task<IList<RatingBuildModel>> GetAllBuildRatings(int id);
        Task<IList<RatingComponentModel>> GetAllComponentRatings(int id);
    }
}