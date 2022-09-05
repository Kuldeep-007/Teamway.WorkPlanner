using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Teamway.WorkPlanner.Data.Migrations
{
    public partial class tw_work_planner_devContext : DbContext
    {
        public tw_work_planner_devContext()
        {
        }

        public tw_work_planner_devContext(DbContextOptions<tw_work_planner_devContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Credential> Credentials { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;
        public virtual DbSet<WorkerShift> WorkerShifts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=103.86.177.20;Database=tw_work_planner_dev;UID=blackdogdbuser;PWD=Bala#007;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credential>(entity =>
            {
                entity.ToTable("Credential");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Credentials)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Credential_Credential");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("Worker");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdentityId).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.OfficialMail).HasMaxLength(50);

                entity.Property(e => e.PersonalMail).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<WorkerShift>(entity =>
            {
                entity.ToTable("WorkerShift");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.WorkerShifts)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkerShift_Worker");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
