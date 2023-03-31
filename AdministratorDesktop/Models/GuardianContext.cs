using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdministratorDesktop.Models;

public partial class GuardianContext : DbContext
{
    public GuardianContext()
    {
    }

    public GuardianContext(DbContextOptions<GuardianContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPost> UserPosts { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("database=guardian;server=localhost;user=root;password=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Post, "Post_idx");

            entity.HasIndex(e => e.Type, "Type_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FullName)
                .HasColumnType("text")
                .HasColumnName("Full_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Login).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Photo).HasColumnType("text");
            entity.Property(e => e.SecretWord)
                .HasMaxLength(45)
                .HasColumnName("Secret_word");

            entity.HasOne(d => d.PostNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Post");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("Type");
        });

        modelBuilder.Entity<UserPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_post");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
