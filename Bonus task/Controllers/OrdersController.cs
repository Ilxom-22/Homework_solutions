using Bonus_task.CompositionServices;
using Bonus_task.Interfaces;
using Bonus_task.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bonus_task.Controllers;

[ApiController]
[Route("api/[controller]")]

public class OrdersController : ControllerBase
{
    private readonly IEntityBaseService<Order> _orderService;
    private readonly UserOrdersService _userOrdersService;

    public OrdersController(IEntityBaseService<Order> orderService, UserOrdersService userOrdersService)
    {
        _orderService = orderService;
        _userOrdersService = userOrdersService;
    }

    [HttpGet("orders/:userId")]
    public IActionResult GetUserOrders(Guid userId)
        => Ok(_userOrdersService.Get(userId));

    [HttpPost]
    public IActionResult AddOrder(Order order)
        => Ok(_orderService.CreateAsync(order));
}
