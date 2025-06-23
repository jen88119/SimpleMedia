using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimpleMedia.Entities
{
    public partial class SimpleMediaContext : DbContext
    {
        public SimpleMediaContext()
        {
        }

        public SimpleMediaContext(DbContextOptions<SimpleMediaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comment { get; set; } = null!;
        public virtual DbSet<Post> Post { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.LastMaintainDt).HasColumnType("datetime");

                entity.Property(e => e.UserID)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.PostID)
                    //.OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Post");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Content).HasMaxLength(200);

                entity.Property(e => e.LastMaintainDt).HasColumnType("datetime");

                entity.Property(e => e.UserID)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserID)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Biography).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(512);

                entity.Property(e => e.Salt).HasMaxLength(512);

                entity.Property(e => e.UserName).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
