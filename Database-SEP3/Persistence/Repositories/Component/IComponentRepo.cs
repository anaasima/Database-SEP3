using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Component;

namespace Database_SEP3.Persistence.Repositories.Component
{
    public interface IComponentRepo
    {
        public Task CreateComponent(ComponentModel componentModel);
        public Task<ComponentList> ReadComponents();
        public Task UpdateComponent(ComponentModel componentModel);
        public Task DeleteComponent(int componentId);
        public Task<ComponentList> GetComponentsFromBuild(int buildId);
        public Task AddComponentToBuild(int buildId, int componentId);
        public Task RemoveComponentFromBuild(int buildId, int componentId);
    }
}