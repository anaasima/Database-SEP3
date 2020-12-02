using System;
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
            _account = await _accountRepo.ReadAccount(username, password);
            string reply = JsonSerializer.Serialize(_account);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void Register(string content)
        {
            AccountModel dummy = JsonSerializer.Deserialize<AccountModel>(content);
            await _accountRepo.CreateAccount(dummy);
        }

        public async void Edit(string content)
        {
            AccountModel dummy = JsonSerializer.Deserialize<AccountModel>(content);
            await _accountRepo.UpdateAccount(dummy);
        }
        
        public async void Delete(string content)
        {
            AccountModel dummy = JsonSerializer.Deserialize<AccountModel>(content);
            await _accountRepo.DeleteAccount(dummy.UserId);
        }
    }
}