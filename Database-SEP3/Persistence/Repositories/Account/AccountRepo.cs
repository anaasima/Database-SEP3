using System;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model.Account;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Account
{
    public class AccountRepo : IAccountRepo
    {
        private Sep3DBContext _context;

        public async Task CreateAccount(AccountModel accountModel)
        {
            await using (_context = new Sep3DBContext())
            {
                foreach (var variable in _context.Accounts)
                {
                    if (variable.Username.Equals(accountModel.Username))
                    {
                        Console.WriteLine("Account already exists");
                        return;
                    }
                }
                await _context.Accounts.AddAsync(accountModel);
                Console.WriteLine(accountModel.Username);
                Console.WriteLine("Account successfully created");
                await _context.SaveChangesAsync();
            }
        }

        public async Task<AccountModel> ReadAccount(string username, string password)
        {
            await using (_context = new Sep3DBContext())
            {
                return _context.Accounts.First(a => a.Username.Equals(username) && a.Password.Equals(password));
            }
        }
    }
}