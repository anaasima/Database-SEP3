using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Database_SEP3.Persistence.Model.Comment;

namespace Database_SEP3.Persistence.Model.Post
{
    public class PostModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("userId")]
        public int AccountModelUserId { get; set; }
        
        [JsonPropertyName("upVote")]
        public int UpVote { get; set; }
        [JsonPropertyName("downVote")]
        public int DownVote { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        
        // [NotMapped]
        // [JsonPropertyName("commentList")]
        // public IList<CommentModel> CommentList { get; set; }
        
        [JsonPropertyName("comments")]
        public ICollection<CommentModel> Comments { get; set; }

        public override string ToString()
        {
            return Id + ", " + UpVote + ", " + DownVote;
        }
    }
}