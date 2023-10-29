using File_Upload.Models.Identity;
using File_Upload.Services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace File_Upload.Controller;

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
    public async ValueTask<IActionResult> RegisterAsync(RegisterDetails registrationDetails)
        => Ok(await _authService.RegisterAsync(registrationDetails));

    [HttpPost("login")]
    public async ValueTask<IActionResult> LoginAsync(LoginDetails loginDetails)
        => Ok(await _authService.LoginAsync(loginDetails));
}