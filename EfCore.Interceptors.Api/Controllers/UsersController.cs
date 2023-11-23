using AutoMapper;
using EfCore.Interceptors.Api.Models.Dtos;
using EfCore.Interceptors.Application.Common.Identity.Services;
using EfCore.Interceptors.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Interceptors.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IMapper mapper, IUserService userService) : ControllerBase
{
    /// <summary>
    /// Gets all users.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var users = await userService.Get().ToListAsync();
        return users.Any() ? Ok(mapper.Map<IEnumerable<UserDto>>(users)) : NotFound();
    }

    /// <summary>
    /// Gets a user by ID.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> GetUserById([FromRoute] Guid userId)
    {
        var user = await userService.GetByIdAsync(userId);
        return user != null ? Ok(mapper.Map<UserDto>(user)) : NotFound();
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] UserDto user)
    {
        var createdUser = await userService.CreateAsync(mapper.Map<User>(user));
        return CreatedAtAction(
            nameof(GetUserById),
            new
            {
                userId = createdUser.Id,
            },
            mapper.Map<UserDto>(createdUser)
        );
    }

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] UserDto user)
    {
        await userService.UpdateAsync(mapper.Map<User>(user));
        return Ok();
    }

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpDelete("{userId:guid}")]
    public async ValueTask<IActionResult> DeleteByIdAsync([FromRoute] Guid userId)
    {
        await userService.DeleteByIdAsync(userId);
        return Ok();
    }
}