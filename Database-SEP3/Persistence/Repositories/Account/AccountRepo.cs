using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<string> CreateAccount(AccountModel accountModel)
        {
            await using (_context = new Sep3DBContext())
            {
                foreach (var variable in _context.Accounts)
                {
                    if (variable.Username.Equals(accountModel.Username))
                    {
                        Console.WriteLine("Account already exists");
                        return "Account already exists";
                    }
                }
                await _context.Accounts.AddAsync(accountModel);
                Console.WriteLine(accountModel.Username);
                Console.WriteLine("Account successfully created");
                await _context.SaveChangesAsync();
            }

            return "Account successfully created";
        }

        public async Task<AccountModel> ReadAccount(string username, string password)
        {
            try
            {
                await using (_context = new Sep3DBContext())
                {
                    return _context.Accounts.First(a => a.Username.Equals(username) && a.Password.Equals(password));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Account does not exist");
            }

            return null;
        }

        public async Task DeleteAccount(int userId)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModel = await _context.Accounts
                    .Include(a => a.Builds)
                    .ThenInclude(b => b.BuildComponents)
                    .Include(acc => acc.Posts)
                    .FirstAsync(account => account.UserId == userId);
                _context.Accounts.Remove(accountModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> UpdateAccount(AccountModel accountModel)
        {
            await using (_context = new Sep3DBContext())
            {
                foreach (var variable in _context.Accounts)
                {
                    if (variable.Username.Equals(accountModel.Username))
                    {
                        Console.WriteLine("Account already exists");
                        return "Account already exists";
                    }
                }
                
                _context.Accounts.Update(accountModel);
                await _context.SaveChangesAsync();
            }

            return "Account updated";
        }

        public async Task<AccountModel> GetAccountByUsername(string username)
        {
            await using (_context = new Sep3DBContext())
            {
                return await _context.Accounts.FirstAsync(a => a.Username.Equals(username));
            }
        }
    }
}