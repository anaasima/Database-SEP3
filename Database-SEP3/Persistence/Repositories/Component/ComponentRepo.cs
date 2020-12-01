using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Networking.Util;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Component;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Component
{
public class ComponentRepo : IComponentRepo
{
    private Sep3DBContext _context;
    private ComponentList _componentList;


    public ComponentRepo()
    {
        _componentList = new ComponentList();
    }
    public async Task CreateComponent(ComponentModel componentModel)
    {
        await using (_context = new Sep3DBContext())
        {
            await _context.Components.AddAsync(componentModel);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<ComponentList> ReadComponents()
    {
        _componentList = new ComponentList();
        await using (_context = new Sep3DBContext())
        {
            foreach (var variable in _context.Components)
            {
                _componentList.AddComponent(variable);
            }

            return _componentList;
        }
    }

    public async Task UpdateComponent(ComponentModel componentModel)
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
            ComponentModel component = await _context.Components.FirstAsync(c => c.Id == componentId);
            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<ComponentList> GetComponentsFromBuild(int buildId)
    {
        _componentList = new ComponentList();
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
                ComponentModel componentModel = await _context.Components.FirstAsync(c => c.Id == id);
                _componentList.AddComponent(componentModel);
            }

            for (int i = 0; i < _componentList.Size(); i++)
            {
                Console.WriteLine(_componentList.GetComponent(i));
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
                .First(buildcomp => buildcomp.ComponentModel.Id == componentId);
            _context.Remove(buildComponent);
            Console.WriteLine("removed component");
            await _context.SaveChangesAsync();
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

            foreach (var VARIABLE in buildModel.BuildComponents)
            {
                Console.WriteLine("buildId= " + VARIABLE.BuildId + "\n Build model= " + VARIABLE.BuildModel.ToString() + "componentId= " + VARIABLE.ComponentId + "\n Component model= " + VARIABLE.ComponentModel.ToString());
            }
                
            _context.Update(buildModel);
            await _context.SaveChangesAsync();
        }
    }
}
}
