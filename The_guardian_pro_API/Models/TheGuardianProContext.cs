using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace The_guardian_pro_API.Models;

public partial class TheGuardianProContext : DbContext
{
    public TheGuardianProContext()
    {
    }

    public TheGuardianProContext(DbContextOptions<TheGuardianProContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<PurposOfTheVisit> PurposOfTheVisits { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;database=the_guardian_pro;user=root;password=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasColumnType("text");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("division");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("text");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PRIMARY");

            entity.ToTable("groups");

            entity.Property(e => e.GroupId)
                .ValueGeneratedNever()
                .HasColumnName("Group_id");
            entity.Property(e => e.DateOfCreation).HasColumnName("Date_of_creation");
            entity.Property(e => e.Name).HasColumnType("text");
        });

        modelBuilder.Entity<PurposOfTheVisit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("purpos_of_the_visit");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("text");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("requests");

            entity.HasIndex(e => e.Division, "Division_idx");

            entity.HasIndex(e => e.GroupId, "Group_idx");

            entity.HasIndex(e => e.Status, "Visitor");

            entity.HasIndex(e => e.VisitorId, "Visitor_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(10);

            entity.HasOne(d => d.DivisionNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.Division)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Division");

            entity.HasOne(d => d.Group).WithMany(p => p.Requests)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("Groups");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("Status");

            entity.HasOne(d => d.Visitor).WithMany(p => p.Requests)
                .HasForeignKey(d => d.VisitorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Visitors");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PRIMARY");

            entity.ToTable("staff");

            entity.HasIndex(e => e.Division, "Department_idx");

            entity.HasIndex(e => e.Department, "Division_idx");

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("Staff_id");
            entity.Property(e => e.FullName)
                .HasColumnType("text")
                .HasColumnName("Full_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Discription).HasColumnType("text");
            entity.Property(e => e.Status1).HasColumnName("Status");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.VisitId).HasName("PRIMARY");

            entity.ToTable("visit");

            entity.HasIndex(e => e.GroupId, "Group_idx");

            entity.HasIndex(e => e.VisitorId, "Visitor_idx");

            entity.Property(e => e.VisitId)
                .ValueGeneratedNever()
                .HasColumnName("Visit_id");
            entity.Property(e => e.GroupId).HasColumnName("Group_id");
            entity.Property(e => e.VisitDate)
                .HasColumnType("datetime")
                .HasColumnName("Visit_date");
            entity.Property(e => e.VisitorId).HasColumnName("Visitor_id");

            entity.HasOne(d => d.Group).WithMany(p => p.Visits)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("Group");

            entity.HasOne(d => d.Visitor).WithMany(p => p.Visits)
                .HasForeignKey(d => d.VisitorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Visitor");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("visitor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasColumnType("text");
            entity.Property(e => e.FullName)
                .HasColumnType("text")
                .HasColumnName("Full_name");
            entity.Property(e => e.Login).HasColumnType("text");
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(45)
                .HasColumnName("Phone_number");
            entity.Property(e => e.VisitorPassport)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("Visitor_passport");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
