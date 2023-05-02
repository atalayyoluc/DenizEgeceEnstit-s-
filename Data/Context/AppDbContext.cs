using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>()
                .HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<Post>()
                .HasMany(p => p.PostTags)
                .WithOne(tr => tr.Post).IsRequired();

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.PostTags).WithOne(tr => tr.Tag).IsRequired();


            modelBuilder.Entity<User>().HasMany(x => x.Children).WithOne(x => x.InvitedBy).HasForeignKey(g => g.InvitedById).OnDelete(DeleteBehavior.NoAction);

        }

    }
}
