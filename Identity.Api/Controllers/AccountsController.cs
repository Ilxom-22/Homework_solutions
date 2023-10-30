using Identity.Application.Common.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
        => _accountService = accountService;

    [HttpPut("verification/{token}")]
    public async ValueTask<IActionResult> VerificateAsync([FromRoute] string token)
        => Ok(await _accountService.VerificateAsync(token));
}