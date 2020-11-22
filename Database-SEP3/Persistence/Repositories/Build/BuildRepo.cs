using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model.Build;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Build
{
    public class BuildRepo : IBuildRepo
    {
        private Sep3DBContext _context;
        private BuildList _list;
        
        public async Task<BuildList> ReadBuilds()
        {
            _list = new BuildList();
            await using (_context = new Sep3DBContext())
            {
                foreach (var variable in _context.Builds)
                { 
                    _list.AddBuild(variable);
                }

                return _list;
            }
        }
    }
}