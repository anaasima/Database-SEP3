using System;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model.Account;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private Sep3DBContext _context;

        public async void createAccount(AccountModel accountModel)
        {
            await using (_context = new Sep3DBContext())
            {
                foreach (var VARIABLE in _context.Accounts)
                {
                    if (VARIABLE.Username.Equals(accountModel.Username))
                    {
                        Console.WriteLine("Account already exists");
                        return;
                    }
                }
                await _context.Accounts.AddAsync(accountModel);
                Console.WriteLine("Account successfully created");
            }
        }

        public async Task<AccountModel> readAccount(int id)
        {
            await using (_context = new Sep3DBContext())
            {
                return _context.Accounts.First(a => a.UserId == id);
            }
        }
    }
}