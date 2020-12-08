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
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Build
{
    public class BuildRepo : IBuildRepo
    {
        private Sep3DBContext _context;
        
        public async Task<BuildModel> ReadBuild(int buildId)
        {
            await using (_context = new Sep3DBContext())
            {
                return await _context.Builds.Include(b => b.BuildComponents)
                    .ThenInclude(bld => bld.ComponentModel).FirstAsync(build => build.Id == buildId);
            }
        }
        
        // parametri build model si lista cu componentele lui
        public async Task CreateBuild(BuildModel buildModel)
        {
            await using (_context = new Sep3DBContext())
            {
                //adaug buildu in database
                await _context.Builds.AddAsync(buildModel);
                await _context.SaveChangesAsync();
                // iau contul din database
                AccountModel accountModel = await _context.Accounts
                    .Include(a => a.Builds)
                    .FirstAsync(account => account.UserId == buildModel.AccountModelUserId);
                // iau buildu din database

                BuildModel databaseBuild = await _context.Builds.OrderBy(b => b.Id).LastAsync();
                Console.WriteLine("build citit din database");
                //adaug buildu in cont si dau update
                if (accountModel.Builds == null)
                {
                    accountModel.Builds = new List<BuildModel>();
                }
                accountModel.Builds.Add(databaseBuild);
                Console.WriteLine("build pus in cont");
                _context.Update(accountModel);
                Console.WriteLine("cont updatat");
                //iau fiecare component din database si ii adaug buildului
                Console.WriteLine(databaseBuild.ComponentList.Count);
                if (databaseBuild.BuildComponents == null)
                {
                    databaseBuild.BuildComponents = new List<BuildComponent>();
                    Console.WriteLine("initialized buildComponent list");
                }
                for(var i = 0; i < databaseBuild.ComponentList.Count; i++)
                {
                    ComponentModel arg = await _context.Components.FirstAsync(c => c.Id == databaseBuild.ComponentList[i].Id);
                    Console.WriteLine("component luat din database");
                    BuildComponent buildComponent = new BuildComponent
                    {
                        BuildId = databaseBuild.Id,
                        BuildModel = databaseBuild,
                        ComponentId = arg.Id,
                        ComponentModel = arg
                    };
                    databaseBuild.BuildComponents.Add(buildComponent);
                }
                // dau update la build si salvez databazu
                _context.Update(databaseBuild);
                await _context.SaveChangesAsync();
                Console.WriteLine("build creat si salvat");
            }
        }

        public async Task AddBuilds(IList<BuildModel> builds, int userId) //Whats with this?
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel account = _context.Accounts.First(a => a.UserId ==
                                                                    userId);
                Console.WriteLine(account.Username + " took from database to put builds in");
                if (account.Builds == null)
                {
                    account.Builds = new List<BuildModel>();
                }
                foreach (var VARIABLE in builds)
                {
                    account.Builds.Add(VARIABLE);
                }

                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditBuilds(BuildModel buildModel)
        {
            await using (_context = new Sep3DBContext())
            {
                BuildModel buildModelDatabase = await _context.Builds
                    .Include(b => b.BuildComponents)
                    .FirstAsync(build => build.Id == buildModel.Id);
                buildModelDatabase.Name = buildModel.Name;
                buildModelDatabase.BuildComponents = new Collection<BuildComponent>();
                for (int i = 0; i < buildModel.ComponentList.Count; i++)
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

        public async Task DeleteBuild(int buildId)
        {
            await using (_context = new Sep3DBContext())
            {
                BuildModel buildModel = await _context.Builds
                    .Include(b => b.BuildComponents)
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
                AccountModel account = _context.Accounts.Include(acc => acc.Builds).First(a => a.UserId ==
                    userId);
                Console.WriteLine(account.ToString() + " took from database to get builds from");
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