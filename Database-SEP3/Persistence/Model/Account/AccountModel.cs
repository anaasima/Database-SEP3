using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Database_SEP3.Persistence.Model.Build;

namespace Database_SEP3.Persistence.Model.Account
{
    public class AccountModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
        public String Name { get; set; }
        public ICollection<BuildModel> Builds { get; set; }
    }
}