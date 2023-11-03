using LearningCenter.Domain.Entities.Common.Identity;

namespace LearningCenter.Domain.Entities.Courses;

public class Course
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;

    public Guid TeacherId { get; set; }

    public virtual User Teacher { get; set; }

    public virtual ICollection<CourseStudent> CourseStudents { get; set; }
}