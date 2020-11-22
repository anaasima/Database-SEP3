using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Database_SEP3.Persistence.Model.Build;

namespace Database_SEP3.Persistence.Model.Account
{
    public class AccountModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int UserId { get; set; }    //TODO: change name maybe
        [Required]
        [JsonPropertyName("username")]
        public String Username { get; set; }
        [Required]
        [JsonPropertyName("password")]
        public String Password { get; set; }
        [JsonPropertyName("name")]
        public String Name { get; set; }
        [JsonPropertyName("buildList")]
        
        public ICollection<BuildModel> Builds { get; set; }
    }
}