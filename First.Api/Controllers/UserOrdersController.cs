using First.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace First.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserOrdersController : ControllerBase
{
    private readonly UserOrdersService _userOrdersService;

    public UserOrdersController(UserOrdersService userOrdersService)
    {
        _userOrdersService = userOrdersService;
    }

    [HttpGet]
    public IActionResult Get(Guid id)
    {
        return Ok(_userOrdersService.Get(id));
    }
}
