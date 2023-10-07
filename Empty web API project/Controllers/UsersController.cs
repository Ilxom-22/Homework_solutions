using Empty_web_API_project.Services;
using Empty_web_API_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Empty_web_API_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IEntityBase<User> _userService;

   
    public UsersController(IEntityBase<User> userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_userService.Get(user => true).ToList());
    }

    [HttpPost]
    public async ValueTask<IActionResult> AddUser(User user)
    {
        return Ok(await _userService.CreateAsync(user));
    }

    [HttpPut]
    public IActionResult UpdateUser(User user)
    {
        return Ok(_userService.UpdateAsync(user));
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> GetUser(Guid id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }

    [HttpDelete("{userId:guid}")]
    public async ValueTask<IActionResult> DeleteUser(Guid id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteUser(User user)
    {
        await _userService.DeleteAsync(user);
        return NoContent();
    }
}