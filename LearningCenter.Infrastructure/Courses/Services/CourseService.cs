using LearningCenter.Application.Courses.Services;
using LearningCenter.Domain.Entities.Courses;
using LearningCenter.Persistence.DataContexts;
using System.Linq.Expressions;

namespace LearningCenter.Infrastructure.Courses.Services;

public class CourseService : ICourseService
{
    private readonly AppDbContext _appDbContext;

    public CourseService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<Course> Get(Expression<Func<Course, bool>>? predicate)
        => predicate != null ? _appDbContext.Courses.Where(predicate) : _appDbContext.Courses;

    public async ValueTask<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _appDbContext.Courses.FindAsync(id);

    public async ValueTask<Course> CreateAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _appDbContext.Courses.AddAsync(course, cancellationToken);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return course;
    }

    public async ValueTask<Course> UpdateAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundCourse = await GetByIdAsync(course.Id, cancellationToken) ?? throw new ArgumentException("Course not found!");

        foundCourse.Title = course.Title;
        foundCourse.Description = course.Description;
        foundCourse.TeacherId = course.TeacherId;

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return foundCourse;
    }

    public async ValueTask<Course> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundCourse = await GetByIdAsync(id, cancellationToken) ?? throw new ArgumentException("Course not found");

        _appDbContext.Courses.Remove(foundCourse);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return foundCourse;
    }

    public async ValueTask<Course> DeleteAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default)
        => await DeleteByIdAsync(course.Id, saveChanges, cancellationToken);
}