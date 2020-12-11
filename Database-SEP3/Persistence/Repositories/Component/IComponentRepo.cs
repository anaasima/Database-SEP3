using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;

namespace Database_SEP3.Persistence.Repositories.Component
{
    public interface IComponentRepo    //i guess gray methods are for testing
    {
        Task CreateComponent(ComponentModel componentModel);
        Task<IList<ComponentModel>> ReadComponents();
        Task UpdateComponent(ComponentModel componentModel);
        Task DeleteComponent(int componentId);
        Task<IList<ComponentModel>> GetComponentsFromBuild(int buildId);
        Task AddComponentToBuild(int buildId, int componentId);
        Task RemoveComponentFromBuild(int buildId, int componentId);
        Task<ComponentModel> GetComponentById(int componentId);
        Task<IList<ComponentModel>> GetFilteredList(string type);
    }
}