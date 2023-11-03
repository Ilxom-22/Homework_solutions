using LearningCenter.Application.Courses.Services;
using LearningCenter.Domain.Entities.Courses;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public IActionResult GetAllCourses()
        => Ok(_courseService.Get(null));

    [HttpGet("{courseId}")]
    public async ValueTask<IActionResult> GetCourseById(Guid courseId)
        => Ok(await _courseService.GetByIdAsync(courseId));

    [HttpPost]
    public async ValueTask<IActionResult> CreateCourse(Course course)
        => Ok(await _courseService.CreateAsync(course));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateCourseAsync(Course course)
        => Ok(await _courseService.UpdateAsync(course));

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteCourseAsync(Course course)
        => Ok(await _courseService.DeleteAsync(course));

    [HttpDelete("{courseId}")]
    public async ValueTask<IActionResult> DeleteCourseByIdAsync(Guid courseId)
        => Ok(await _courseService.DeleteByIdAsync(courseId));
}