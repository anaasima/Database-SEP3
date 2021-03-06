using System.ComponentModel.DataAnnotations.Schema;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Forum.Report;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Model.Rating;
using Database_SEP3.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.DataAccess
{
    public class Sep3DBContext : DbContext
    {
        public DbSet<ComponentModel> Components { get; set; }
        public DbSet<BuildModel> Builds { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<RatingBuildModel> RatingBuild { get; set; }
        public DbSet<RatingComponentModel> RatingComponent { get; set; }
        public DbSet<RatingPostModel> RatingPost { get; set; }
        public DbSet<ReportModel> Reports { get; set; }
        public DbSet<AccountFollowedAccount> AccountFollowedAccounts { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\University\DNP\Database-SEP3\Database-SEP3\luckyDatabaseTier3FINAL");
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

            modelBuilder.Entity<PostModel>()
                .HasOne<AccountModel>(p => p.AccountModel)
                .WithMany(a => a.Posts)
                .HasForeignKey(a => a.AccountModelUserId);
            
            modelBuilder.Entity<AccountSavedPost>()
                .HasKey(sc => 
                    new
                    {
                        sc.AccountId, 
                        sc.SavedPostId
                    }
                );
            
            modelBuilder.Entity<AccountSavedPost>()
                .HasOne(asp => asp.AccountModel)
                .WithMany(a => a.SavedPosts)
                .HasForeignKey(aa => aa.AccountId);
            
            modelBuilder.Entity<AccountSavedPost>()
                .HasOne(asp => asp.SavedPostModel)
                .WithMany(p => p.SavedPosts)
                .HasForeignKey(sa => sa.SavedPostId);
            
            modelBuilder.Entity<AccountFollowedAccount>()
                .HasKey(sc => 
                    new
                    {
                        sc.AccountModelUserId, 
                        sc.FollowedAccountModelUserId
                    }
                );

            modelBuilder.Entity<AccountFollowedAccount>()
                .HasOne(afa => afa.AccountModel)
                .WithMany();
            
            modelBuilder.Entity<AccountFollowedAccount>()
                .HasOne(afa => afa.FollowedAccountModel)
                .WithMany();
        }
    }
}