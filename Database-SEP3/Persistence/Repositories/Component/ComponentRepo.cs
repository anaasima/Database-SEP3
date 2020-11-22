using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Database_SEP3.Networking.Util;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories
{
public class ComponentRepo : IComponentRepo
{
    private Sep3DBContext _context;
    private ComponentList _componentList;


    public ComponentRepo()
    {
        _componentList = new ComponentList();
    }
    public async Task CreateComponent()
    {
        ComponentModel c1 = new ComponentModel  //TODO: this will later woosh
        {
            Id = 2,
            Type = "CPU",
            Name = "Intel i5",
            Brand = "Gigabyte",
            ReleaseYear = "2019",
            AdditionalInfo = "sdf"
        };
        await using (_context = new Sep3DBContext())
        {
            await _context.Components.AddAsync(c1);
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

    public Task UpdateComponent()
    {
        throw new System.NotImplementedException();
    }

    public Task DeleteComponent()
    {
        throw new System.NotImplementedException();
    }
}
}
