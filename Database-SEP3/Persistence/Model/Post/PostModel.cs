using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Database_SEP3.Persistence.Model.Comment;

namespace Database_SEP3.Persistence.Model.Post
{
    public class PostModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("upvote")]
        public int UpVote { get; set; }
        [JsonPropertyName("downvote")]
        public int DownVote { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        
        public ICollection<CommentModel> Comments { get; set; }

        public override string ToString()
        {
            return Id + ", " + UpVote + ", " + DownVote;
        }
    }
}