using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Rating;


namespace Database_SEP3.Persistence.Model.Build
{
    public class BuildModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("userId")]
        public int AccountModelUserId { get; set; }
        
        [JsonPropertyName("name")]
        public String Name { get; set; }
        
        [JsonIgnore]
        public IList<BuildComponent> BuildComponents { get; set; }
        
        [NotMapped]
        [JsonPropertyName("componentList")]
        public IList<ComponentModel> ComponentList { get; set; }
        
        [JsonPropertyName("ratingBuilds")]
        public IList<RatingBuildModel> Ratings { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + AccountModelUserId + " " + BuildComponents;
        }
    }
}