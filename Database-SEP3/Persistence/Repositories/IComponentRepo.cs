using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;

namespace Database_SEP3.Persistence.Repositories
{
    public interface IComponentRepo
    {
        public Task createComponent();
        public Task<List<ComponentModel>> readComponents();
        public Task updateComponent();
        public Task deleteComponent();
    }
}