using Authorization.Api.Models.Identity;
using Authorization.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async ValueTask<IActionResult> RegisterAsync(RegistrationDetails registrationDetails)
        => Ok(await _authService.RegisterAsync(registrationDetails));

    [HttpPost("login")]
    public async ValueTask<IActionResult> LoginAsync(LoginDetails loginDetails)
        => Ok(await _authService.LoginAsync(loginDetails));
}