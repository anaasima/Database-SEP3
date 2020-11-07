using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Database_SEP3.Persistence.Model
{
    public class Component
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Type { get; set; }
        [Required]
        public String ReleaseYear { get; set; }
        [Required]
        public String Brand { get; set; }
        public String AdditionalInfo { get; set; }

    }
}