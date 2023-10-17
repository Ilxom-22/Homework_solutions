using Bonus_task.Models;
using Bonus_task.Interfaces;

namespace Bonus_task.CompositionServices;

public class UserOrdersService
{
    private readonly IEntityBaseService<Order> _orderService;

    public UserOrdersService(IEntityBaseService<Order> orderService)
    {
        _orderService = orderService;
    }

    public IEnumerable<Order> Get(Guid userId)
        => _orderService.Get(order => order.UserId == userId);
    

    public double GetUserOrdersSum(Guid userId)
        =>  Get(userId).Select(order => order.Amount).Sum();
}