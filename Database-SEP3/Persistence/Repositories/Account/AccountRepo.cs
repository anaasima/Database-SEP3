using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;
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

        public async Task AddBuilds(IList<BuildModel> builds, int userId) //Whats with this?
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel account = _context.Accounts.First(a => a.UserId ==
                                             userId);
                Console.WriteLine(account.Username);
                foreach (var VARIABLE in builds)
                {
                    if (account.Builds == null)
                    {
                        account.Builds = new List<BuildModel>();
                    }
                    account.Builds.Add(VARIABLE);
                }

                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}