using Empty_web_API_project.Models;

namespace Empty_web_API_project.Services;

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