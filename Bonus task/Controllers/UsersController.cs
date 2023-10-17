using Bonus_task.Interfaces;
using Bonus_task.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bonus_task.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly IEntityBaseService<User> _userService;

    public UsersController(IEntityBaseService<User> userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
        => Ok(_userService.Get(user => true));

    [HttpGet(":userId")]
    public async ValueTask<IActionResult> GetUser(Guid userId)
        => Ok(await _userService.GetByIdAsync(userId));

    [HttpPost]
    public async ValueTask<IActionResult> CreateUser(User user)
        => Ok(await _userService.CreateAsync(user));
}