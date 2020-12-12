using Database_SEP3.Persistence.Model.Account;

namespace Database_SEP3.Persistence.Model
{
    public class AccountFollowedAccount
    {
        public int AccountModelUserId { get; set; }
        public AccountModel AccountModel { get; set; }
        public int FollowedAccountModelUserId { get; set; }
        public AccountModel FollowedAccountModel { get; set; }
    }
}