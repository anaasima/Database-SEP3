using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Build;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Build
{
    public class BuildRepo : IBuildRepo
    {
        private Sep3DBContext _context;
        private BuildList _list;
        
        public async Task<BuildList> ReadBuilds(int userId)
        {
            _list = new BuildList();
            await using (_context = new Sep3DBContext())
            {
                IList<BuildModel> array = new List<BuildModel>();
                array = await _context.Builds.Where(b => b.UserId == userId).ToListAsync();

                foreach (var VARIABLE in array)
                {
                    _list.AddBuild(VARIABLE);
                }

                Console.WriteLine(_list.ToString());
                
                return _list;
            }
        }

        public async Task AddComponentToBuild(int buildId, int componentId)
        {
            await using (_context = new Sep3DBContext())
            {
                BuildModel buildModel = await _context.Builds.FirstAsync(b => b.Id == buildId);
                ComponentModel componentModel = await _context.Components.FirstAsync(c => c.Id == componentId);
                BuildComponent buildComponent = new BuildComponent
                {
                    BuildModel = buildModel,
                    ComponentModel = componentModel
                };
                if (buildModel.BuildComponents == null)
                {
                    buildModel.BuildComponents = new List<BuildComponent>();
                    buildModel.BuildComponents.Add(buildComponent);
                    Console.WriteLine("added from null");
                }
                else
                {
                    buildModel.BuildComponents.Add(buildComponent);
                    Console.WriteLine("added from existed");
                }

                foreach (var VARIABLE in buildModel.BuildComponents)
                {
                    Console.WriteLine("buildId= " + VARIABLE.BuildId + "\n Build model= " + VARIABLE.BuildModel.ToString() + "componentId= " + VARIABLE.ComponentId + "\n Component model= " + VARIABLE.ComponentModel.ToString());
                }
                
                _context.Update(buildModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveComponentFromBuild(int buildId, int componentId)
        {
            await using (_context = new Sep3DBContext())
            {
                BuildComponent buildComponent = _context.Builds
                    .Where(b => b.Id == buildId)
                    .SelectMany(build => build.BuildComponents)
                    .First(buildcomp => buildcomp.ComponentModel.Id == componentId);
                _context.Remove(buildComponent);
                Console.WriteLine("removed component");
                await _context.SaveChangesAsync();
            }
        }
    }
}