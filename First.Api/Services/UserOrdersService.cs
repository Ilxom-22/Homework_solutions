using First.Api.Models;

namespace First.Api.Services;

public class UserOrdersService
{
    private readonly IEntityBase<Order> _orderService;

    public UserOrdersService(IEntityBase<Order> orderService)
    {
        _orderService = orderService;
    }

    public IEnumerable<Order> Get(Guid userId)
    {
        return _orderService.Get(order => order.UserId == userId);
    }
}