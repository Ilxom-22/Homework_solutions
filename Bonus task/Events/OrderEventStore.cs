using Bonus_task.Models;

namespace Bonus_task.Events;

public class OrderEventStore
{
    public event Func<Order, ValueTask>? OnOrderCreated;

    public async ValueTask CreateOrderCreatedEvent(Order order)
    {
        if (OnOrderCreated != null)
            await OnOrderCreated(order);
    }
}