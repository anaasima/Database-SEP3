using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Build;


namespace Database_SEP3.Persistence.Repositories.Build
{
    public interface IBuildRepo
    {
        Task<BuildModel> ReadBuild(int buildId); //?for testing?
        Task CreateBuild(BuildModel buildModel);
        Task<IList<BuildModel>> GetBuildsFromAccount(int userId);
        Task AddBuilds(IList<BuildModel> builds, int userId); //for testing
        Task EditBuild(BuildModel buildModel);
        Task DeleteBuild(int buildId);
    }
}