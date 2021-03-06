using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Networking.Util;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Rating;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Component
{
public class ComponentRepo : IComponentRepo
{
    private Sep3DBContext _context;
    private IList<ComponentModel> _componentList;

    public ComponentRepo()
    {
        _componentList = new List<ComponentModel>();
    }
    public async Task CreateComponent(ComponentModel componentModel)
    {
        await using (_context = new Sep3DBContext())
        {
            componentModel.Ratings = new Collection<RatingComponentModel>();
            await _context.Components.AddAsync(componentModel);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IList<ComponentModel>> GetComponents()
    {
        await using (_context = new Sep3DBContext())
        {
            return await _context.Components
                .Include(c => c.Ratings)
                .ToListAsync();
            
        }
    }

    public async Task EditComponent(ComponentModel componentModel)
    {
        await using (_context = new Sep3DBContext())
        {
            _context.Components.Update(componentModel);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteComponent(int componentId)
    {
        await using (_context = new Sep3DBContext())
        {
            ComponentModel component = await _context.Components
                .Include(c => c.Ratings)
                .Include(c => c.BuildComponents)
                .FirstAsync(c => c.Id == componentId);
            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IList<ComponentModel>> GetComponentsFromBuild(int buildId)
    {
        _componentList = new List<ComponentModel>();
        await using (_context = new Sep3DBContext())
        {
            BuildModel database = await _context.Builds
                .Include(build => build.BuildComponents)
                .ThenInclude(bc => bc.ComponentModel)
                .FirstAsync(b => b.Id == buildId);
            Console.WriteLine("Build model: " + database.Id);
            IList<BuildComponent> buildComponents = database.BuildComponents.ToList();
            foreach (var variable in buildComponents)
            {
                int id = variable.ComponentModel.Id;
                ComponentModel componentModel = await _context.Components
                    .Include(c => c.Ratings)
                    .FirstAsync(c => c.Id == id);
                _componentList.Add(componentModel);
            }
            return _componentList;
        }
    }
    
    public async Task RemoveComponentFromBuild(int buildId, int componentId)
    {
        await using (_context = new Sep3DBContext())
        {
            BuildComponent buildComponent = _context.Builds
                .Where(b => b.Id == buildId)
                .SelectMany(build => build.BuildComponents)
                .First(build => build.ComponentModel.Id == componentId);
            _context.Remove(buildComponent);
            Console.WriteLine("removed component");
            await _context.SaveChangesAsync();
        }
    }

    public async Task<ComponentModel> GetComponentById(int componentId)
    {
        await using (_context = new Sep3DBContext())
        {
            return await _context.Components
                .Include(c => c.Ratings)
                .FirstAsync(c => c.Id == componentId);
        }
    }

    public async Task<IList<ComponentModel>> GetFilteredList(string type)
    {
        await using (_context = new Sep3DBContext())
        {
            return await _context.Components
                .Include(c => c.Ratings)
                .Where(c => c.Type.Equals(type)).ToListAsync();
        }
    }

    public async Task<ComponentModel> GetComponentByName(string name)
    {
        await using (_context = new Sep3DBContext())
        {
            return await _context.Components
                .FirstAsync(c => c.Name == name);
        }
    }

    public async Task AddComponentToBuild(int buildId, int componentId)
    {
        await using (_context = new Sep3DBContext())
        {
            BuildModel buildModel = await _context.Builds.FirstAsync(b => b.Id == buildId);
            ComponentModel componentModel = await _context.Components
                .Include(c => c.Ratings)
                .FirstAsync(c => c.Id == componentId);
            BuildComponent buildComponent = new BuildComponent
            {
                BuildId = buildModel.Id,
                BuildModel = buildModel,
                ComponentId = componentModel.Id,
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

            foreach (var variable in buildModel.BuildComponents)
            {
                Console.WriteLine("buildId= " + variable.BuildId + "\n Build model= " + variable.BuildModel + "componentId= " + variable.ComponentId + 
                                  "\n Component model= " + variable.ComponentModel);
            }
            _context.Update(buildModel);
            await _context.SaveChangesAsync();
        }
    }
}
}
