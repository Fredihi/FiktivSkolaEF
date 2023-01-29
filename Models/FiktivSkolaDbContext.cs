using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FiktivSkolaEF.Models
{
    public partial class FiktivSkolaDbContext : DbContext
    {
        public FiktivSkolaDbContext()
        {
        }

        public FiktivSkolaDbContext(DbContextOptions<FiktivSkolaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConnectionTable> ConnectionTables { get; set; } = null!;
        public virtual DbSet<DateGrade> DateGrades { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<StaffPosition> StaffPositions { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = FRED; Initial Catalog = FiktivSkola; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectionTable>(entity =>
            {
                entity.ToTable("ConnectionTable");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DateGradeId).HasColumnName("DateGradeID");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.StaffPositionId).HasColumnName("StaffPositionID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.DateGrade)
                    .WithMany(p => p.ConnectionTables)
                    .HasForeignKey(d => d.DateGradeId)
                    .HasConstraintName("FK_ConnectionTable_DateGrade");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.ConnectionTables)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectionTable_Grades");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.ConnectionTables)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectionTable_Staff");

                entity.HasOne(d => d.StaffPosition)
                    .WithMany(p => p.ConnectionTables)
                    .HasForeignKey(d => d.StaffPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectionTable_StaffPosition");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ConnectionTables)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectionTable_Student");
            });

            modelBuilder.Entity<DateGrade>(entity =>
            {
                entity.ToTable("DateGrade");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.GradeDate).HasColumnType("date");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Grade1)
                    .HasMaxLength(10)
                    .HasColumnName("Grade")
                    .IsFixedLength();
            });

            modelBuilder.Entity<StaffPosition>(entity =>
            {
                entity.ToTable("StaffPosition");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.StaffPosition1)
                    .HasMaxLength(50)
                    .HasColumnName("StaffPosition");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Staff_StaffPosition");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
