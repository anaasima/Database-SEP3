using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Rating;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Build
{
    public class BuildRepo : IBuildRepo
    {
        private Sep3DBContext _context;
        
        public async Task<BuildModel> GetBuild(int buildId)
        {
            await using (_context = new Sep3DBContext())
            {
                return await _context.Builds
                    .Include(b => b.BuildComponents)
                    .ThenInclude(bld => bld.ComponentModel)
                    .Include(c => c.Ratings)
                    .Include(r => r.Ratings)
                    .FirstAsync(build => build.Id == buildId);
            }
        }
        
        public async Task CreateBuild(BuildModel buildModel)
        {
            await using (_context = new Sep3DBContext())
            {
                buildModel.Ratings = new List<RatingBuildModel>();
                await _context.Builds.AddAsync(buildModel);
                await _context.SaveChangesAsync();
                
                AccountModel accountModel = await _context.Accounts
                    .Include(a => a.Builds)
                    .FirstAsync(account => account.UserId == buildModel.AccountModelUserId);

                BuildModel databaseBuild = await _context.Builds.OrderBy(b => b.Id).LastAsync();
                if (accountModel.Builds == null)
                {
                    accountModel.Builds = new List<BuildModel>();
                }
                accountModel.Builds.Add(databaseBuild);
                _context.Update(accountModel);
                
                if (databaseBuild.BuildComponents == null)
                {
                    databaseBuild.BuildComponents = new List<BuildComponent>();
                }
                
                for(var i = 0; i < databaseBuild.ComponentList.Count; i++)
                {
                    ComponentModel arg = await _context.Components.FirstAsync(c => c.Id == databaseBuild.ComponentList[i].Id);
                    BuildComponent buildComponent = new BuildComponent
                    {
                        BuildId = databaseBuild.Id,
                        BuildModel = databaseBuild,
                        ComponentId = arg.Id,
                        ComponentModel = arg
                    };
                    databaseBuild.BuildComponents.Add(buildComponent);
                }
                
                _context.Update(databaseBuild);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBuild(int buildId)
        {
            await using (_context = new Sep3DBContext())
            {
                BuildModel buildModel = await _context.Builds
                    .Include(b => b.BuildComponents)
                    .Include(r => r.Ratings)
                    .FirstAsync(build => build.Id == buildId);
                buildModel.BuildComponents = new Collection<BuildComponent>();
                _context.Builds.Remove(buildModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<BuildModel>> GetBuildsFromAccount(int userId)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel account = _context.Accounts
                    .Include(acc => acc.Builds)
                    .ThenInclude(r => r.Ratings)
                    .First(a => a.UserId == userId);
                IList<BuildModel> buildList = new List<BuildModel>();
                foreach (var build in account.Builds)
                {
                    buildList.Add(build);
                    Console.WriteLine(build.ToString());
                }

                return buildList;
            }
        }

        public async Task EditBuild(BuildModel buildModel)
        {
            await using (_context = new Sep3DBContext())
            {
                BuildModel buildModelDatabase = await _context.Builds
                    .Include(b => b.BuildComponents)
                    .FirstAsync(bld => bld.Id == buildModel.Id);
                buildModelDatabase.Name = buildModel.Name;
                buildModelDatabase.BuildComponents = new Collection<BuildComponent>();
                
                for(var i = 0; i < buildModel.ComponentList.Count(); i++)
                {
                    ComponentModel arg = await _context.Components
                        .FirstAsync(c => c.Id == buildModel.ComponentList[i].Id);
                    BuildComponent buildComponent = new BuildComponent
                    {
                        BuildId = buildModelDatabase.Id,
                        BuildModel = buildModelDatabase,
                        ComponentId = arg.Id,
                        ComponentModel = arg
                    };
                    buildModelDatabase.BuildComponents.Add(buildComponent);
                }
                
                _context.Update(buildModelDatabase);
                await _context.SaveChangesAsync();
            }
        }
    }
}