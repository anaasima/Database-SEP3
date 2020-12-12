using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Repositories.Account;

namespace Database_SEP3.Networking.Account
{
    public class Server_AccountHandler
    {
        private AccountModel _account;
        private IAccountRepo _accountRepo;

        public Server_AccountHandler()
        {
            _account = new AccountModel();
            _accountRepo = new AccountRepo();
        }

        public async void GetMyAccount(NetworkStream stream, string content)
        {
            AccountModel dummy = JsonSerializer.Deserialize<AccountModel>(content);
            string username = dummy.Username;
            string password = dummy.Password;
            _account = await _accountRepo.GetAccount(username, password);
            string reply = JsonSerializer.Serialize(_account);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void Register(NetworkStream stream, string content)
        {
            AccountModel dummy = JsonSerializer.Deserialize<AccountModel>(content);
            string input = await _accountRepo.CreateAccount(dummy);
            string reply = JsonSerializer.Serialize(input);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void Edit(NetworkStream stream, string content)
        {
            AccountModel dummy = JsonSerializer.Deserialize<AccountModel>(content);
            String input = await _accountRepo.EditAccount(dummy);
            string reply = JsonSerializer.Serialize(input);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
        
        public async void Delete(string content)
        {
            await _accountRepo.DeleteAccount(Int32.Parse(content));
        }

        public async void GetAccountByUsername(NetworkStream stream, string content)
        {
            AccountModel dummy = JsonSerializer.Deserialize<AccountModel>(content);
            string username = dummy.Username;
            _account = await _accountRepo.GetAccountByUsername(username);
            string reply = JsonSerializer.Serialize(_account);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void GetFollowedAccounts(NetworkStream stream, string req1Content)
        {
            IList<AccountModel> accountModels = await _accountRepo.GetFollowedAccounts(Int32.Parse(req1Content));
            string reply = JsonSerializer.Serialize(accountModels);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void Follow(string content)
        {
            string[] substrings = content.Split('*');
            int userId = Int32.Parse(substrings[0]);
            int userToFollow = Int32.Parse(substrings[1]);
            await _accountRepo.FollowAccount(userId, userToFollow);
        }


        public async void Unfollow(string content)
        {
            string[] substrings = content.Split('*');
            int userId = Int32.Parse(substrings[0]);
            int userToUnfollow = Int32.Parse(substrings[1]);
            await _accountRepo.UnfollowAccount(userId, userToUnfollow);
        }

        public async void GetUserById(NetworkStream stream, string req1Content)
        {
            AccountModel accountModel = await _accountRepo.GetAccountById(Int32.Parse(req1Content));
            string reply = JsonSerializer.Serialize(accountModel);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
    }
}