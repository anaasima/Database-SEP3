using System.Threading.Tasks;
using Database_SEP3.Persistence.Model.Rating;

namespace Database_SEP3.Persistence.Repositories.Rating
{
    public interface IRatingRepo
    {
        Task CreateBuildRating(RatingBuildModel ratingBuildModel);
        Task CreatePostRating(RatingPostModel ratingPostModel);
        Task CreateComponentRating(RatingComponentModel ratingComponentModel);
    }
}