using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Repositories;

namespace Database_SEP3.Networking.Account
{
    public class Server_AccountHandler
    {
        private AccountModel _account;
        private AccountRepo _accountRepo;

        public Server_AccountHandler()
        {
            _account = new AccountModel();
            _accountRepo = new AccountRepo();
        }

        public async void GetMyAccount(NetworkStream stream, object content)
        {
            AccountModel dummy = (AccountModel) content;
            string username = dummy.Username;
            string password = dummy.Password;
            _account = await _accountRepo.ReadAccount(username, password);
            
            string reply = JsonSerializer.Serialize(_account);
            Console.WriteLine(reply);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void Register(NetworkStream stream, object content)
        {
            AccountModel dummy = (AccountModel) content;
            await _accountRepo.CreateAccount(dummy);
            
            // string reply = JsonSerializer.Serialize("Your account has been created");
            // Console.WriteLine(reply);
            // byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            // stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
    }
}