using System.Threading.Tasks;
using Database_SEP3.Persistence.Model.Account;

namespace Database_SEP3.Persistence.Repositories
{
    public interface IAccountRepo
    {
        public Task CreateAccount(AccountModel accountModel);
        public Task<AccountModel> ReadAccount(string username, string password);
    }
}