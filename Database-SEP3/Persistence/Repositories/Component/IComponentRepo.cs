using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;

namespace Database_SEP3.Persistence.Repositories.Component
{
    public interface IComponentRepo
    {
        public Task CreateComponent(ComponentModel componentModel);
        public Task<IList<ComponentModel>> ReadComponents();
        public Task UpdateComponent(ComponentModel componentModel);
        public Task DeleteComponent(int componentId);
        public Task<IList<ComponentModel>> GetComponentsFromBuild(int buildId);
        public Task AddComponentToBuild(int buildId, int componentId);
        public Task RemoveComponentFromBuild(int buildId, int componentId);
    }
}