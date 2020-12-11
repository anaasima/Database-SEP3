using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Forum.Report;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Model.Rating;

namespace Database_SEP3.Persistence.Model.Account
{
    public class AccountModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int UserId { get; set; }  
        
        [JsonPropertyName("followedAccounts")]
        public ICollection<AccountFollowedAccount> AccountFollowedAccounts { get; set; }
        
        
        
        
        
        [Required]
        [JsonPropertyName("username")]
        public String Username { get; set; }
        [Required]
        [JsonPropertyName("password")]
        public String Password { get; set; }
        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("savedPosts")]
        public ICollection<AccountSavedPost> SavedPosts { get; set; }
        
        [JsonIgnore]    //remember
        public ICollection<ReportModel> Reports { get; set; }
        
        [JsonPropertyName("posts")]
        public ICollection<PostModel> Posts { get; set; }
        
        //Delete json ignore if you need any of these things later
        [JsonIgnore]
        public ICollection<BuildModel> Builds { get; set; }
       
        [JsonIgnore]
        public ICollection<CommentModel> Comments { get; set; }
        [JsonIgnore]
        public ICollection<RatingBuildModel> BuildRatings { get; set; }
        [JsonIgnore]
        public ICollection<RatingComponentModel> ComponentRatings { get; set; }
        [JsonIgnore]
        public ICollection<RatingPostModel> PostRatings { get; set; }



        public override string ToString()
        {
            return UserId + ", " + Username;
        }
    }
}