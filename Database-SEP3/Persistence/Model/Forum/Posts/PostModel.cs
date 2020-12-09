using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Forum.Report;
using Database_SEP3.Persistence.Model.Rating;

namespace Database_SEP3.Persistence.Model.Post
{
    public class PostModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("userId")]
        public int AccountModelUserId { get; set; }
        
        public AccountModel AccountModel { get; set; }
        
        [JsonPropertyName("upVote")]
        public int UpVote { get; set; }
        [JsonPropertyName("downVote")]
        public int DownVote { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("savedPosts")]
        public ICollection<AccountSavedPost> SavedPosts { get; set; }
        
        [JsonPropertyName("comments")]
        public ICollection<CommentModel> Comments { get; set; }

        [JsonPropertyName("ratingPosts")]
        public IList<RatingPostModel> Ratings { get; set; }
        
        [JsonIgnore] //remember
        public ICollection<ReportModel> Reports { get; set; }

        public override string ToString()
        {
            return Id + ", " + UpVote + ", " + DownVote;
        }
    }
}