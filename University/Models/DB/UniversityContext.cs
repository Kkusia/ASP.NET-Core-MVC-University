using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.DB
{
    public partial class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("DafaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasMany(e => e.Groups).WithOne(e => e.Course).IsRequired();
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__COURSES__71CB31DB78360ECE");

                entity.ToTable("COURSES");

                entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasMany(e => e.Students).WithOne(e => e.Group).IsRequired();
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__GROUPS__3EFEA3DE59D9078C");

                entity.ToTable("GROUPS");

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(e => e.Group).WithMany(e => e.Students).IsRequired();
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__STUDENTS__E69FE77BA98C7C38");

                entity.ToTable("STUDENTS");

                entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

        }
    }
}
