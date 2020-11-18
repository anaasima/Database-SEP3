using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database_SEP3.Persistence.Model.Account;

namespace Database_SEP3.Persistence.Model.Build
{
    public class BuildModel
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public IList<BuildComponent> BuildComponents { get; set; }
    }
}