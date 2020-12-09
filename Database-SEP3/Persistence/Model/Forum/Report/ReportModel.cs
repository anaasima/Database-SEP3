using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Database_SEP3.Persistence.Model.Post;

namespace Database_SEP3.Persistence.Model.Forum.Report
{
    public class ReportModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("postId")]
        public int PostModelId { get; set; }
        [NotMapped]
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("userId")]
        public int AccountModelId { get; set; }
    }
}