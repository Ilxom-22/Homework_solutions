using EfCore.Interceptors.Application.Common.Identity.Models;
using EfCore.Interceptors.Application.Common.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Interceptors.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("signUp")]
    public async ValueTask<IActionResult> SignUpAsync(UserDetails userDetails)
        => Ok(await authService.SignUpAsync(userDetails));

    [HttpPost("signIn")]
    public IActionResult SignInAsync(UserDetails userDetails)
        => Ok(authService.SignInAsync(userDetails));
}