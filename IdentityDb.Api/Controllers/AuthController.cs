using IdentityDb.Application.Common.Identity.Models;
using IdentityDb.Application.Common.Identity.Services;
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
}