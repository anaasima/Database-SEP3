using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Model.Rating;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

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
                accountModel.Builds = new List<BuildModel>();
                accountModel.Comments = new List<CommentModel>();
                accountModel.Posts = new List<PostModel>();
                accountModel.BuildRatings = new List<RatingBuildModel>();
                accountModel.PostRatings = new List<RatingPostModel>();
                accountModel.SavedPosts = new List<AccountSavedPost>();
                accountModel.FollowedUsers = new List<AccountModel>();
                await _context.Accounts.AddAsync(accountModel);
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
                    return _context.Accounts
                        .First(a => a.Username.Equals(username) && a.Password.Equals(password));
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
                    .ThenInclude(p => p.Comments)
                    .FirstAsync(account => account.UserId == userId);
                foreach (var build in accountModel.Builds)
                {
                    build.BuildComponents = new Collection<BuildComponent>();
                }
                foreach (var post in accountModel.Posts)
                {
                    post.Comments = new Collection<CommentModel>();
                }
                accountModel.Builds = new Collection<BuildModel>();
                accountModel.Posts = new Collection<PostModel>();
                _context.Accounts.Remove(accountModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> UpdateAccount(AccountModel accountModel)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModelDatabase = await _context.Accounts
                    .Include(a => a.Posts)
                    .FirstAsync(acc => acc.UserId == accountModel.UserId);
                accountModelDatabase.Username = accountModel.Username;
                accountModelDatabase.Password = accountModel.Password;
                accountModelDatabase.Name = accountModel.Name;
                foreach (var post in accountModelDatabase.Posts)
                {
                    post.Username = accountModel.Username;
                }
                _context.Accounts.Update(accountModelDatabase);
                await _context.SaveChangesAsync();
            }
            return "Account updated";
        }

        public async Task<AccountModel> GetAccountByUsername(string username)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModel = await _context.Accounts
                    .Include(acc => acc.Posts)
                    .FirstAsync(a => a.Username.Equals(username));

                return accountModel;
            }
        }

        public async Task<AccountModel> GetAccountById(int userId)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModel = await _context.Accounts
                    .Include(acc => acc.Posts)
                    .ThenInclude(p => p.Comments)
                    .Include(a => a.Builds)
                    .Include(a => a.Comments)
                    .Include(a => a.Reports)
                    .Include(a => a.SavedPosts)
                    .Include(a => a.FollowedUsers)
                    .FirstAsync(a => a.UserId == userId);

                return accountModel;
            }
        }

        public async Task<IList<AccountModel>> GetFollowedAccounts(int userId)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModel = await _context.Accounts
                    .Include(acc => acc.FollowedUsers)
                    .FirstAsync(a => a.UserId == userId);

                return accountModel.FollowedUsers.ToList();
            }
        }

        public async Task FollowAccount(int userId, int followId)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModel = await _context.Accounts
                    .Include(acc => acc.FollowedUsers)
                    .FirstAsync(a => a.UserId == userId);

                AccountModel follow = await _context.Accounts
                    .FirstAsync(a => a.UserId == followId);
                accountModel.FollowedUsers.Add(follow);
                _context.Update(accountModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UnfollowAccount(int userId, int followId)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModel = await _context.Accounts
                    .Include(acc => acc.FollowedUsers)
                    .FirstAsync(a => a.UserId == userId);

                accountModel.FollowedUsers
                    .Remove(accountModel.FollowedUsers
                        .First(a => a.UserId == followId));
                
                _context.Update(accountModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}