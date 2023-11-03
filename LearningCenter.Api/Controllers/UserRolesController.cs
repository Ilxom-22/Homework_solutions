using LearningCenter.Application.Common.Identity.Services;
using LearningCenter.Domain.Entities.Common.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IUserRoleService _userRoleService;

    public UserRolesController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpGet]
    public IActionResult GetAllUserRoles()
        => Ok(_userRoleService.Get(null));

    [HttpGet("{userRoleId}")]
    public async ValueTask<IActionResult> GetUserRoleById(Guid userRoleId)
        => Ok(await _userRoleService.GetByIdAsync(userRoleId));

    [HttpPost]
    public async ValueTask<IActionResult> CreateUserRoleAsync(UserRole userRole)
        => Ok(await _userRoleService.CreateAsync(userRole));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateUserRoleAsync(UserRole userRole)
        => Ok(await _userRoleService.UpdateAsync(userRole));

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteUserRoleAsync(UserRole userRole)
        => Ok(await _userRoleService.DeleteAsync(userRole));

    [HttpDelete("{userRoleId}")]
    public async ValueTask<IActionResult> DeleteUserRoleByIdAsync(Guid userRoleId)
        => Ok(await _userRoleService.DeleteByIdAsync(userRoleId));
}