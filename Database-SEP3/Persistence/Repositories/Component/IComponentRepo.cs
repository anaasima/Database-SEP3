using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;

namespace Database_SEP3.Persistence.Repositories.Component
{
    public interface IComponentRepo    //i guess gray methods are for testing
    {
        Task CreateComponent(ComponentModel componentModel);
        Task<IList<ComponentModel>> GetComponents();
        Task EditComponent(ComponentModel componentModel);
        Task DeleteComponent(int componentId);
        Task<IList<ComponentModel>> GetComponentsFromBuild(int buildId);//is used
        Task AddComponentToBuild(int buildId, int componentId);//testing
        Task RemoveComponentFromBuild(int buildId, int componentId);//testing
        Task<ComponentModel> GetComponentById(int componentId);//testing
        Task<IList<ComponentModel>> GetFilteredList(string type);
        Task<ComponentModel> GetComponentByName(string name);//testing
    }
}