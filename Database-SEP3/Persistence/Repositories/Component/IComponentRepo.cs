using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;

namespace Database_SEP3.Persistence.Repositories
{
    public interface IComponentRepo
    {
        public Task CreateComponent();
        public Task<ComponentList> ReadComponents();
        public Task UpdateComponent();
        public Task DeleteComponent();
    }
}