using LearningCenter.Domain.Entities.Courses;

namespace LearningCenter.Domain.Entities.Common.Identity;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public virtual ICollection<CourseStudent> CourseStudents { get; set; }

    public virtual ICollection<Course> TeacherCourses { get; set; }
}