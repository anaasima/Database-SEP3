using Database_SEP3.Persistence.Model.Account;

namespace Database_SEP3.Persistence.Model
{
    public class AccountFollowedAccount
    {
        public int AccountId { get; set; }
        public AccountModel AccountModel { get; set; }
        public int FollowedAccountId { get; set; }
        public AccountModel FollowedAccountModel { get; set; }
    }
}