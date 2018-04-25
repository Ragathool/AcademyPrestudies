using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AcademyPrestudies.Models.Entities
{
    public partial class MuninContext : DbContext
    {
        public virtual DbSet<CourseProgress> CourseProgress { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<Links> Links { get; set; }
        public virtual DbSet<Tips> Tips { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=prestudies.database.windows.net;Initial Catalog=Odin;Integrated Security=False;User ID=ACD;Password=prestudies18!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseProgress>(entity =>
            {
                entity.ToTable("CourseProgress", "pre");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.ToTable("Courses", "pre");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("Exercise", "pre");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Exercise)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exercise_Courses");
            });

            modelBuilder.Entity<Links>(entity =>
            {
                entity.ToTable("Links", "pre");

                entity.Property(e => e.LinkInfo).HasMaxLength(50);

                entity.Property(e => e.Url).HasMaxLength(100);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Links)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Links_Courses");
            });

            modelBuilder.Entity<Tips>(entity =>
            {
                entity.ToTable("Tips", "pre");

                entity.Property(e => e.TipInfo).HasMaxLength(100);

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.Tips)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tips_Exercise");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "pre");

                entity.Property(e => e.AspNetUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
