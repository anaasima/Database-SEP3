using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;

namespace Database_SEP3.Persistence.Repositories.Account
{
    public interface IAccountRepo
    {
        public Task<string> CreateAccount(AccountModel accountModel);
        public Task<AccountModel> ReadAccount(string username, string password);
        public Task DeleteAccount(int userId);
        public Task<string> UpdateAccount(AccountModel accountModel);
        public Task<AccountModel> GetAccountByUsername(string username);
    }
}