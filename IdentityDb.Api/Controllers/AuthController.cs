using IdentityDb.Application.Common.Constants;
using IdentityDb.Application.Common.Identity.Models;
using IdentityDb.Application.Common.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("signup")]
    public async ValueTask<IActionResult> SignUpAsync([FromBody] SignUpDetails signUpDetails, CancellationToken cancellationToken) => 
        Ok(await _authService.SignUpAsync(signUpDetails, cancellationToken));

    [HttpPost("signin")]
    public async ValueTask<IActionResult> SignInAsync([FromBody] SignInDetails signInDetails, CancellationToken cancellationToken) =>
        Ok(await _authService.SignInAsync(signInDetails, cancellationToken));

    [Authorize(Roles = "Admin")]
    [HttpPut("users/{userId:guid}/roles/{roleType}")]
    public async ValueTask<IActionResult> GrantRole([FromRoute] Guid userId, [FromRoute] string roleType, CancellationToken cancellationToken)
    {
        var actionUserId = Guid.Parse(User.Claims.First(claim => claim.Type.Equals(ClaimConstants.UserId)).Value);
        var result = await _authService.GrantRole(userId, roleType, actionUserId, cancellationToken);

        return result ? Ok(result) : BadRequest();
    }
}