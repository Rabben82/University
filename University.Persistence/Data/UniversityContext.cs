using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Core.Entities;

namespace University.Persistence.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; } = default!;
        // public DbSet<Enrollment> Enrollments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<Enrollment>(
                    e => e.HasOne(e => e.Course).WithMany(c => c.Enrollments),
                    e => e.HasOne(e => e.Student).WithMany(c => c.Enrollments),
                    e => e.HasKey(e => new { e.StudentId, e.CourseId }));

           // modelBuilder.Entity<Enrollment>().HasKey(e => new { e.StudentId, e.CourseId });
        }
    }
}
