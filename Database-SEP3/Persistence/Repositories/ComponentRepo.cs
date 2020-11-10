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
    private ComponentList componentList;
        
    public async Task createComponent()
    {
        ComponentModel c1 = new ComponentModel
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

    public Task<List<ComponentModel>> readComponents()
    {
        using (_context = new Sep3DBContext())
        {
            return _context.Components.ToListAsync();
        }
    }

    public Task updateComponent()
    {
        throw new System.NotImplementedException();
    }

    public Task deleteComponent()
    {
        throw new System.NotImplementedException();
    }
}
}
