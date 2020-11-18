using System.Threading.Tasks;
using Database_SEP3.Persistence.Model.Account;

namespace Database_SEP3.Persistence.Repositories
{
    public interface IAccountRepo
    {
        public void createAccount(AccountModel accountModel);
        public Task<AccountModel> readAccount(int id);
    }
}