using LearningCenter.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningCenter.Persistence.EntityConfigurations;

public class StudentCourseConfigurations : IEntityTypeConfiguration<CourseStudent>
{
    public void Configure(EntityTypeBuilder<CourseStudent> builder)
    {
        builder.HasKey(x => new {x.CourseId, x.StudentId});

        builder.HasOne(x => x.Course).WithMany(i => i.CourseStudents).HasForeignKey(x => x.CourseId);

        builder.HasOne(x => x.Course).WithMany(i => i.CourseStudents).HasForeignKey(x => x.StudentId);  
    }
}