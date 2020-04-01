using BlogPost_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPost_WebAPI.Context
{
    public class BlogPostContext : DbContext
    {

        public BlogPostContext(DbContextOptions<BlogPostContext> options)
            : base(options)
        {
        }

        public DbSet<Models.BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.BlogPost>()
                .HasKey(x => x.Id);
                
            modelBuilder.Entity<Tag>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<BlogPostTag>()
                .HasKey(x => new { x.BlogPostId, x.TagId });
            modelBuilder.Entity<BlogPostTag>()
                .HasOne(x => x.BlogPost)
                .WithMany(m => m.Tags)
                .HasForeignKey(x => x.BlogPostId);
            modelBuilder.Entity<BlogPostTag>()
                .HasOne(x => x.Tag)
                .WithMany(e => e.BlogPosts)
                .HasForeignKey(x => x.TagId);
        }

        public DbSet<BlogPost_WebAPI.Models.BlogPostTag> BlogPostTag { get; set; }
    }
}


