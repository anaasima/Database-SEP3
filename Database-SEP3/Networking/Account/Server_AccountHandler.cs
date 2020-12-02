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
            String input = await _accountRepo.UpdateAccount(dummy);
            string reply = JsonSerializer.Serialize(input);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
        
        public async void Delete(string content)
        {
            Console.WriteLine(content);
            await _accountRepo.DeleteAccount(Int32.Parse(content));
        }
    }
}