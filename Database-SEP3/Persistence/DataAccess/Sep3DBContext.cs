using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.DataAccess
{
    public class Sep3DBContext : DbContext
    {
        public DbSet<ComponentModel> Components { get; set; }
        public DbSet<BuildModel> Builds { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\ajurj\RiderProjects\Database-SEP3\Database-SEP3\SEP3Database");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BuildComponent>()
                .HasKey(sc => 
                    new
                    {
                        sc.BuildId, 
                        sc.ComponentId
                    }
                );

            modelBuilder.Entity<BuildComponent>()
                .HasOne(bc => bc.BuildModel)
                .WithMany(build => build.BuildComponents)
                .HasForeignKey(bc => bc.BuildId);
            
            modelBuilder.Entity<BuildComponent>()
                .HasOne(bc => bc.ComponentModel)
                .WithMany(component => component.BuildComponents)
                .HasForeignKey(bc => bc.ComponentId);
        }
    }
}