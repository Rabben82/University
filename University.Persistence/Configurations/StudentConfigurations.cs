using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Entities;

namespace University.Persistence.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.OwnsOne(s => s.Name)
            .Property(n => n.FirstName)
            .HasColumnName("FirstName");


            builder.OwnsOne(s => s.Name)
            .Property(n => n.LastName)
            .HasColumnName("LastName");


            builder.HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Courses)
            .WithMany(c => c.Students)
            .UsingEntity<Enrollment>(
                e => e.HasOne(e => e.Course).WithMany(c => c.Enrollments),
                e => e.HasOne(e => e.Student).WithMany(c => c.Enrollments),
                e => e.HasKey(e => new { e.StudentId, e.CourseId }));
        }
    }
}
