using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Database_SEP3.Persistence.Model.Rating
{
    public class RatingBuildModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("userId")]
        public int AccountModelUserId { get; set; }
        [JsonPropertyName("buildId")]
        public int BuildModelId { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }
        
    }
}