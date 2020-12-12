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
                accountModel.ComponentRatings = new List<RatingComponentModel>();
                accountModel.SavedPosts = new List<AccountSavedPost>();
                accountModel.FollowedAccounts = new List<AccountModel>();
                await _context.Accounts.AddAsync(accountModel);
                Console.WriteLine("Account successfully created");
                await _context.SaveChangesAsync();
            }
            return "Account successfully created";
        }

        public async Task<AccountModel> GetAccount(string username, string password)
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
                foreach (var variable in _context.AccountFollowedAccounts)
                {
                    if (variable.AccountModelUserId == userId)
                    {
                        _context.AccountFollowedAccounts.Remove(variable);
                    }
                }
                accountModel.Builds = new Collection<BuildModel>();
                accountModel.Posts = new Collection<PostModel>();
                _context.Accounts.Remove(accountModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> EditAccount(AccountModel accountModel)
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
                    .ThenInclude(p => p.Ratings)
                    .Include(acc => acc.Posts)
                    .ThenInclude(p => p.Comments)
                    .Include(a => a.Builds)
                    .Include(a => a.Comments)
                    .Include(a => a.Reports)
                    .Include(a => a.SavedPosts)
                    .FirstAsync(a => a.UserId == userId);

                foreach (var user in _context.AccountFollowedAccounts)
                {
                    if (user.AccountModelUserId == userId)
                    {
                        accountModel.FollowedAccounts.Add(user.FollowedAccountModel);
                    }
                }
                return accountModel;
            }
        }

        public async Task<IList<AccountModel>> GetFollowedAccounts(int userId)
        {
            await using (_context = new Sep3DBContext())
            {
                IList<AccountModel> list = new List<AccountModel>();
                foreach (var relation in _context.AccountFollowedAccounts)
                {
                    if (relation.AccountModelUserId == userId)
                    {
                        AccountModel followedAccount = await _context.Accounts
                            .FirstAsync(a => a.UserId == relation.FollowedAccountModelUserId);
                        list.Add(followedAccount);
                    }
                }
                return list;
            }
        }

        public async Task FollowAccount(int userId, int followId)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModel = await _context.Accounts
                    .FirstAsync(a => a.UserId == userId);

                AccountModel follow = await _context.Accounts
                    .FirstAsync(a => a.UserId == followId);
                AccountFollowedAccount fol = new AccountFollowedAccount()
                {
                    AccountModelUserId = userId,
                    AccountModel = accountModel,
                    FollowedAccountModelUserId = followId,
                    FollowedAccountModel = follow
                };
                await _context.AccountFollowedAccounts.AddAsync(fol);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UnfollowAccount(int userId, int followId)
        {
            await using (_context = new Sep3DBContext())
            {
                AccountModel accountModel = await _context.Accounts
                    .FirstAsync(a => a.UserId == userId);

                AccountModel follow = await _context.Accounts
                    .FirstAsync(a => a.UserId == followId);

                foreach (var variable in _context.AccountFollowedAccounts)
                {
                    if (variable.AccountModelUserId == userId &&
                        variable.FollowedAccountModelUserId == followId)
                    {
                        _context.AccountFollowedAccounts.Remove(variable);
                        await _context.SaveChangesAsync();
                        return;
                    }
                }
            }
        }
    }
}