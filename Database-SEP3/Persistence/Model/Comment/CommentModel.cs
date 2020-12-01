using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Database_SEP3.Persistence.Model.Comment
{
    public class CommentModel
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

        public override string ToString()
        {
            return Id + ", " + UpVote + ", " + DownVote;
        }
    }
}