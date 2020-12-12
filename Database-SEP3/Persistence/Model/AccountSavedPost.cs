using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Post;

namespace Database_SEP3.Persistence.Model
{
    public class AccountSavedPost
    {
        public int AccountId { get; set; }
        public AccountModel AccountModel { get; set; }
        public int SavedPostId { get; set; }
        public PostModel SavedPostModel { get; set; }
    }
}    