using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Component;

namespace Database_SEP3.Persistence.Model.Build
{
    public class BuildModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public String Name { get; set; }
        [JsonIgnore]
        public IList<BuildComponent> BuildComponents { get; set; }
        
        public override string ToString()
        {
            return Id + " " + Name + " " + " " + BuildComponents;
        }
    }
}