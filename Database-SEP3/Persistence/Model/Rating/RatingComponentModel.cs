using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Database_SEP3.Persistence.Model.Rating
{
    public class RatingComponentModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("userId")]
        public int AccountModelUserId { get; set; }
        [JsonPropertyName("componentId")]
        public int ComponentModelId { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }
        
        public override string ToString()
        {
            return Id + ", " + Score;
        }
    }
}