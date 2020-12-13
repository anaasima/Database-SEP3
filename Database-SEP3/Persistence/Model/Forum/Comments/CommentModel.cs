using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Database_SEP3.Persistence.Model.Comment
{
    public class CommentModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("userId")]
        public int AccountModelUserId { get; set; }
        [JsonPropertyName("postId")]
        public int PostModelId { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }

        public override string ToString()
        {
            return Id + ", " + Content;
        }
    }
}