using Database_SEP3.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.DataAccess
{
    public class Sep3DBContext : DbContext
    {
        public DbSet<ComponentModel> Components { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\University\DNP\Database-SEP3\Database-SEP3\databaseTier3");
        }
    }
}