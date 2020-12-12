using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;

namespace Database_SEP3.Persistence.Repositories.Account
{
    public interface IAccountRepo
    {
        Task<string> CreateAccount(AccountModel accountModel);
        Task<AccountModel> GetAccount(string username, string password);
        Task DeleteAccount(int userId);
        Task<string> EditAccount(AccountModel accountModel);
        Task<AccountModel> GetAccountByUsername(string username);
        Task<AccountModel> GetAccountById(int userId);
        Task<IList<AccountModel>> GetFollowedAccounts(int userId);
        Task FollowAccount(int userId, int followId);
        Task UnfollowAccount(int userId, int followId);
    }
}    