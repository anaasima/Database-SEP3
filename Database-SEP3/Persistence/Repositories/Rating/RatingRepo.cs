using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model.Rating;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Rating
{
    public class RatingRepo : IRatingRepo
    {
        private Sep3DBContext _context;
        
        public async Task CreateBuildRating(RatingBuildModel ratingBuildModel)
        {
            await using (_context = new Sep3DBContext())
            {
                bool exists = await _context.RatingBuild.AnyAsync(r =>
                    r.AccountModelUserId == ratingBuildModel.AccountModelUserId
                    && r.BuildModelId == ratingBuildModel.BuildModelId);
                if (exists)
                {
                    List<RatingBuildModel> list = await _context.RatingBuild
                        .Where(r => r.BuildModelId == ratingBuildModel.BuildModelId &&
                                    r.AccountModelUserId == ratingBuildModel.AccountModelUserId).ToListAsync();
                    RatingBuildModel rating = list[0];
                    rating.Score = ratingBuildModel.Score;
                    _context.RatingBuild.Update(rating);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("rating nu exista  ");
                    await _context.RatingBuild.AddAsync(ratingBuildModel);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task CreatePostRating(RatingPostModel ratingPostModel)
        {
            await using (_context = new Sep3DBContext())
            {
                bool exists = await _context.RatingPost.AnyAsync(r =>
                    r.AccountModelUserId == ratingPostModel.AccountModelUserId
                    && r.PostModelId == ratingPostModel.PostModelId);
                if (exists)
                {
                    List<RatingPostModel> list = await _context.RatingPost
                        .Where(r => r.PostModelId == ratingPostModel.PostModelId &&
                                    r.AccountModelUserId == ratingPostModel.AccountModelUserId).ToListAsync();
                    RatingPostModel rating = list[0];
                    rating.Score = ratingPostModel.Score;
                    _context.RatingPost.Update(rating);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("rating nu exista  ");
                    await _context.RatingPost.AddAsync(ratingPostModel);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task CreateComponentRating(RatingComponentModel ratingComponentModel)
        {
            await using (_context = new Sep3DBContext())
            {
                bool exists = await _context.RatingComponent.AnyAsync(r =>
                    r.AccountModelUserId == ratingComponentModel.AccountModelUserId
                    && r.ComponentModelId == ratingComponentModel.ComponentModelId);
                if (exists)
                {
                    List<RatingComponentModel> list = await _context.RatingComponent
                        .Where(r => r.ComponentModelId == ratingComponentModel.ComponentModelId &&
                                    r.AccountModelUserId == ratingComponentModel.AccountModelUserId).ToListAsync();
                    RatingComponentModel rating = list[0];
                    rating.Score = ratingComponentModel.Score;
                    _context.RatingComponent.Update(rating);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("rating nu exista  ");
                    await _context.RatingComponent.AddAsync(ratingComponentModel);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<IList<RatingPostModel>> GetAllPostRatings(int postId)
        {
            await using (_context = new Sep3DBContext())
            {
                IList<RatingPostModel> ratings = await _context.RatingPost
                    .Where(r => r.PostModelId == postId).ToListAsync();
                return ratings;
            }
        }

        public async Task<IList<RatingBuildModel>> GetAllBuildRatings(int buildId)
        {
            await using (_context = new Sep3DBContext())
            {
                IList<RatingBuildModel> ratings = await _context.RatingBuild
                    .Where(r => r.BuildModelId == buildId).ToListAsync();
                return ratings;
            }
        }

        public async Task<IList<RatingComponentModel>> GetAllComponentRatings(int componentId)
        {
            await using (_context = new Sep3DBContext())
            {
                IList<RatingComponentModel> ratings = await _context.RatingComponent
                    .Where(r => r.ComponentModelId == componentId).ToListAsync();
                return ratings;
            }
        }
    }
}