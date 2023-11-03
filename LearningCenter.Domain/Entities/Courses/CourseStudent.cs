using LearningCenter.Domain.Entities.Common.Identity;

namespace LearningCenter.Domain.Entities.Courses;

public class CourseStudent
{
    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }

    public virtual Course Course { get; set; }

    public virtual User Student { get; set; }
}