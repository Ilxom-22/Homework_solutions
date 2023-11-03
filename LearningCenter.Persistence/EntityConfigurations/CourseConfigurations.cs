using LearningCenter.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningCenter.Persistence.EntityConfigurations;

public class CourseConfigurations : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasOne(course => course.Teacher)
            .WithMany(user => user.TeacherCourses)
            .HasForeignKey(course => course.TeacherId);
    }
}