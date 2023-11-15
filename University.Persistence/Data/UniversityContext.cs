using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Core.Entities;
using University.Persistence.Configurations;

namespace University.Persistence.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Student> Student { get; set; } = default!;
        // public DbSet<Enrollment> Enrollments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentConfigurations());

            //modelBuilder.Entity<Student>().OwnsOne(s => s.Name).ToTable("Name");


            // modelBuilder.Entity<Enrollment>().HasKey(e => new { e.StudentId, e.CourseId });
        }
    }
}
