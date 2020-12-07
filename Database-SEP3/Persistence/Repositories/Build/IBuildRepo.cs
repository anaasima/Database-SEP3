using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Build;


namespace Database_SEP3.Persistence.Repositories.Build
{
    public interface IBuildRepo
    {
        public Task<BuildModel> ReadBuild(int buildId);
        public Task CreateBuild(BuildModel buildModel);
        public Task<IList<BuildModel>> GetBuildsFromAccount(int userId);
        public Task AddBuilds(IList<BuildModel> builds, int userId); //for testing

        public Task EditBuilds(BuildModel buildModel);

        public Task DeleteBuild(int buildId);
    }
}