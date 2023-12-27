using Caching.Application.Common.Identity.Services;
using Caching.Domain.Common.Query;
using Caching.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Caching.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] FilterPagination paginationOptions, CancellationToken cancellationToken = default)
    {
        var querySpecification = new QuerySpecification<User>(paginationOptions.PageSize, paginationOptions.PageToken);

        return Ok(await userService.GetAsync(querySpecification, true, cancellationToken));
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> GetByIdAsync([FromRoute] Guid userId, CancellationToken cancellationToken = default)
    {
        return Ok(await userService.GetByIdAsync(userId, true, cancellationToken));
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateUserAsync([FromBody] User user, CancellationToken cancellationToken = default)
    {
        return Ok(await userService.CreateAsync(user, true, cancellationToken));
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateUserAsync([FromBody] User user, CancellationToken cancellationToken = default)
    {
        return Ok(await userService.UpdateAsync(user, true, cancellationToken));
    }

    [HttpDelete("{userId:guid}")]
    public async ValueTask<IActionResult> DeleteUser([FromRoute] Guid userId, CancellationToken cancellationToken = default)
    {
        return Ok(await userService.DeleteByIdAsync(userId, true, cancellationToken));
    }
}