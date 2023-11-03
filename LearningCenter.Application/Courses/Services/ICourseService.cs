using LearningCenter.Domain.Entities.Courses;
using System.Linq.Expressions;

namespace LearningCenter.Application.Courses.Services;

public interface ICourseService
{
    IQueryable<Course> Get(Expression<Func<Course, bool>>? predicate);

    ValueTask<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<Course> CreateAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Course> UpdateAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Course> DeleteAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Course> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}