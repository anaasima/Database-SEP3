using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    }
}