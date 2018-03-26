using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AcademyPrestudies.Models.Entities
{
    public partial class MuninContext : DbContext
    {

        public virtual DbSet<CourseProgress> CourseProgress { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Munin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseProgress>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseProgress)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseProgress_Courses");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseProgress)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CourseProgress_Users");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
