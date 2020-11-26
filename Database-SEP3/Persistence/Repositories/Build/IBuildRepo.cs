using System.Threading.Tasks;
using Database_SEP3.Persistence.Model.Build;

namespace Database_SEP3.Persistence.Repositories.Build
{
    public interface IBuildRepo
    {
        public Task<BuildList> ReadBuilds(int userId);
    }
}