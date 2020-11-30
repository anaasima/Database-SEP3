using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Build;

namespace Database_SEP3.Persistence.Repositories.Build
{
    public interface IBuildRepo
    {
        public Task<BuildList> ReadBuilds(int userId);
        public Task CreateBuild(BuildModel buildModel, List<ComponentModel> componentModel);
        public Task AddComponentToBuild(int buildId, int componentId);
        public Task RemoveComponentFromBuild(int buildId, int componentId);
    }
}