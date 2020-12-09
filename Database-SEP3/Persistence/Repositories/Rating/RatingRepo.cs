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
                try
                {
                    // RatingBuildModel databaseRating = await _context.RatingBuild
                    //     .FirstAsync(r => r.Id == ratingBuildModel.Id);
                    _context.RatingBuild.Update(ratingBuildModel);
                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    Console.WriteLine("rating nu exista  " + ratingBuildModel.Id);
                    await _context.RatingBuild.AddAsync(ratingBuildModel);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task CreatePostRating(RatingPostModel ratingPostModel)
        {
            await using (_context = new Sep3DBContext())
            {
                try
                {
                    // RatingPostModel databaseRating = await _context.RatingPost
                    //     .FirstAsync(r => r.Id == ratingPostModel.Id);
                    _context.RatingPost.Update(ratingPostModel);
                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    Console.WriteLine("rating nu exista  " + ratingPostModel.Id);
                    await _context.RatingPost.AddAsync(ratingPostModel);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task CreateComponentRating(RatingComponentModel ratingComponentModel)
        {
            await using (_context = new Sep3DBContext())
            {
                try
                {
                    // RatingComponentModel databaseRating = await _context.RatingComponent
                    //     .FirstAsync(r => r.Id == ratingComponentModel.Id);
                    _context.RatingComponent.Update(ratingComponentModel);
                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    Console.WriteLine("rating nu exista  " + ratingComponentModel.Id);
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