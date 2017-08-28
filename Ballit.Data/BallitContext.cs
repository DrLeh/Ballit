using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ballit.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Ballit.Data
{
    public class BallitContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostVote> PostVotes { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentVote> CommentVotes { get; set; }
        //public DbSet<Votable> Votables { get; set; }

        public DbSet<Subballit> Subballits { get; set; }
        public DbSet<User> Users { get; set; }

        public BallitContext(DbContextOptions<BallitContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Ballit;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Votable>()
            //    .HasOne(x => x.CreatedBy)
            //    .WithMany()
            //    .HasForeignKey(x => x.CreatedByUserId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Votable>()
            //    .HasOne(x => x.UpdatedBy)
            //    .WithMany()
            //    .HasForeignKey(x => x.UpdatedByUserId)
            //    .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Vote>()
            //    .HasOne(x => x.User)
            //    .WithMany()
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Vote>()
            //    .HasOne(x => x.Votable)
            //    .WithMany()
            //    .HasForeignKey(x => x.VotableId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Vote>()
            //    .
            //    .HasOne(x => x.Votable)
            //    .WithMany()
            //    .HasForeignKey(x => x.VotableId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Votable>()
            //    .ToTable(nameof(Votable));

            modelBuilder.Entity<Post>()
                .ToTable(nameof(Post));

            modelBuilder.Entity<Comment>()
                .ToTable(nameof(Comment));

            base.OnModelCreating(modelBuilder);
        }
    }
}
