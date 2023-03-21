using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParsethingTasks;

public partial class ParsethingContext : DbContext
{
    public ParsethingContext()
    {
    }

    public ParsethingContext(DbContextOptions<ParsethingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Law> Laws { get; set; }

    public virtual DbSet<Method> Methods { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Procurement> Procurements { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskExecutor> TaskExecutors { get; set; }

    public virtual DbSet<TimeZone> TimeZones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Password=12357;Persist Security Info=True;User ID=33П;Initial Catalog=Parsething;Data Source=ngknn.ru;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Developer>(entity =>
        {
            entity.Property(e => e.FullName).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_Employees_Positions");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.Position1).HasColumnName("Position");
        });

        modelBuilder.Entity<Procurement>(entity =>
        {
            entity.Property(e => e.Deadline).HasColumnType("datetime");
            entity.Property(e => e.InitialPrice).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Warranty)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Law).WithMany(p => p.Procurements)
                .HasForeignKey(d => d.LawId)
                .HasConstraintName("FK_Procurements_Laws");

            entity.HasOne(d => d.Method).WithMany(p => p.Procurements)
                .HasForeignKey(d => d.MethodId)
                .HasConstraintName("FK_Procurements_Methods");

            entity.HasOne(d => d.Organization).WithMany(p => p.Procurements)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_Procurements_Organizations");

            entity.HasOne(d => d.Platform).WithMany(p => p.Procurements)
                .HasForeignKey(d => d.PlatformId)
                .HasConstraintName("FK_Procurements_Platforms");

            entity.HasOne(d => d.TimeZone).WithMany(p => p.Procurements)
                .HasForeignKey(d => d.TimeZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Procurements_TimeZones");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasOne(d => d.Developer).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Developers");
        });

        modelBuilder.Entity<TaskExecutor>(entity =>
        {
            entity.HasOne(d => d.Developer).WithMany(p => p.TaskExecutors)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskExecutors_Developers");

            entity.HasOne(d => d.Status).WithMany(p => p.TaskExecutors)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskExecutors_Statuses");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskExecutors)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskExecutors_Tasks");
        });

        modelBuilder.Entity<TimeZone>(entity =>
        {
            entity.Property(e => e.Offset).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
