using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Component;

namespace Database_SEP3.Persistence.Repositories.Build
{
    public interface IBuildRepo
    {
        public Task<BuildModel> ReadBuild(int buildId);
        public Task CreateBuild(BuildModel buildModel, ComponentList componentModel, int userId);
        public Task<BuildList> GetBuildsFromAccount(int userId);
        public Task AddBuilds(IList<BuildModel> builds, int userId);

        public Task EditBuilds(BuildModel buildModel, ComponentList componentList);

        public Task DeleteBuild(int buildId);
    }
}