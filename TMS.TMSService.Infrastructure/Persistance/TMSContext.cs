using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TMS.TMSService.Domain.Entities;

namespace TMS.TMSService.Infrastructure.Persistance;

public partial class TMSContext : DbContext
{
    public TMSContext()
    {
    }

    public TMSContext(DbContextOptions<TMSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TaskItem> TaskItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=TMS_DB; User ID=SA; Password=4*foryou; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__C3B4DFCA14A5A467");

            entity.ToTable("Comment");

            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.Text)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.TaskItem).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TaskItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__TaskIte__571DF1D5");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__UserId__5629CD9C");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Project__761ABEF0260998F0");

            entity.ToTable("Project");

            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AC178FA1A");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.TaskItemId).HasName("PK__TaskItem__42AA254982EEA106");

            entity.ToTable("TaskItem");

            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DueDate).HasColumnType("date");
            entity.Property(e => e.Priority)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Project).WithMany(p => p.TaskItems)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaskItem__Projec__534D60F1");

            entity.HasOne(d => d.User).WithMany(p => p.TaskItems)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TaskItem__UserId__52593CB8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C03C4D8CF");

            entity.Property(e => e.DisplayName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRole1).HasName("PK__UserRole__81D4C6F1475BC7CD");

            entity.ToTable("UserRole");

            entity.Property(e => e.UserRole1).HasColumnName("UserRole");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
