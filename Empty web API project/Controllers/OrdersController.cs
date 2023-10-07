using Empty_web_API_project.Models;
using Empty_web_API_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Empty_web_API_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IEntityBase<Order> _orderService;

    public OrdersController(IEntityBase<Order> orderService)
    {   
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok(_orderService.Get(order => true));
    }

    [HttpGet("{orderId:guid}")]
    public async ValueTask<IActionResult> GetOrder(Guid id)
    {
        return Ok(await _orderService.GetByIdAsync(id));
    }

    [HttpPost]
    public async ValueTask<IActionResult> AddOrder(Order order)
    {
        return Ok(await _orderService.CreateAsync(order));  
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateOrder(Order order)
    {
        return Ok(await _orderService.UpdateAsync(order));
    }

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteOrder(Order order)
    {
        return Ok(await _orderService.DeleteAsync(order));
    }

    [HttpDelete("{orderId:guid}")]
    public async ValueTask<IActionResult> DeleteOrder(Guid id)
    {
        return Ok(await _orderService.DeleteAsync(id));
    }
}