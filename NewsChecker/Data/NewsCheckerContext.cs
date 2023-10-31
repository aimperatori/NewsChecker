using Microsoft.EntityFrameworkCore;
using NewsChecker.Models;
using System.Reflection.Emit;

namespace NewsChecker.Data
{
    public class NewsCheckerContext : DbContext
    {
        public NewsCheckerContext(DbContextOptions<NewsCheckerContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*builder.Entity<News>()
                .HasMany<Journalist>(_ => _.Journalists)
                .WithMany(_ => _.News);*/

            /*builder.Entity<Journalist>()
                .HasMany<News>(_ => _.News)
                .WithMany(_ => _.Journalist);*/


            builder.Entity<JournalistNews>()
                .HasKey(_ => new { _.JournalistId, _.NewsId });

             builder.Entity<JournalistNews>()
                .HasOne(_ => _.News)
                .WithMany(news => news.JournalistNews)
                .HasForeignKey(_ => _.NewsId);

            builder.Entity<JournalistNews>()
                .HasOne(_ => _.Journalist)
                .WithMany(journalist => journalist.JournalistNews)
                .HasForeignKey(_ => _.JournalistId);
            
        }

        public DbSet<News> News { get; set; }
        public DbSet<Newspapper> Newspapper { get; set; }
        public DbSet<Edition> Edition { get; set; }
        public DbSet<Journalist> Journalist { get; set; }
        public DbSet<JournalistNews> JournalistNews { get; set; }

    }
}
