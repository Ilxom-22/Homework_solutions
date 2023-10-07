using Empty_web_API_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Empty_web_API_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserOrdersController : ControllerBase
{
    private readonly UserOrdersService _userOrdersService;

    public UserOrdersController(UserOrdersService userOrdersService)
    {
        _userOrdersService = userOrdersService;
    }

    [HttpGet("api/orders/by-user/:userId")]
    public IActionResult Get(Guid id)
    {
        return Ok(_userOrdersService.Get(id));
    }
}
