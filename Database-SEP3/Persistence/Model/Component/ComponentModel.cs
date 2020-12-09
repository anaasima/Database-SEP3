using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Database_SEP3.Persistence.Model.Rating;

namespace Database_SEP3.Persistence.Model
{
  
    public class ComponentModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("name")]
        public String Name { get; set; }
        [JsonPropertyName("type")]
        [Required]
        public String Type { get; set; }
        [JsonPropertyName("releaseYear")]
        [Required]
        public String ReleaseYear { get; set; }
        [JsonPropertyName("brand")]
        [Required]
        public String Brand { get; set; }
        [JsonPropertyName("additionalInformation")]
        public String AdditionalInfo { get; set; }
        [JsonPropertyName("socketType")]
        public String SocketType { get; set; }
        [JsonPropertyName("energyConsumption")]
        public int EnergyConsumption { get; set; }
        [JsonIgnore]
        public IList<BuildComponent> BuildComponents { get; set; }
        [JsonPropertyName("ratingComponents")]
        public IList<RatingComponentModel> Ratings { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}