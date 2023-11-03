using LearningCenter.Application.Common.Identity.Services;
using LearningCenter.Domain.Entities.Common.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
        => Ok(_userService.Get(null));

    [HttpGet("{userId}")]
    public async ValueTask<IActionResult> GetUserById(Guid userId)
        => Ok(await _userService.GetByIdAsync(userId));

    [HttpPost]
    public async ValueTask<IActionResult> CreateUserAsync(User user)
        => Ok(await _userService.CreateAsync(user));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateUserAsync(User user)
        => Ok(await _userService.UpdateAsync(user));

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteUserAsync(User user)
        => Ok(await _userService.DeleteAsync(user));

    [HttpDelete("{userId}")]
    public async ValueTask<IActionResult> DeleteUserByIdAsync(Guid userId)
        => Ok(await _userService.DeleteByIdAsync(userId));
}