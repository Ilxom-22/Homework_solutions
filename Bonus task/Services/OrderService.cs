using Bonus_task.Events;
using Bonus_task.Interfaces;
using Bonus_task.Models;
using Bonus_Task.DataAccess;
using System.Linq.Expressions;

namespace Bonus_task.Services;

public class OrderService : IEntityBaseService<Order>
{
    private readonly IDataContext _appDataContext;
    private readonly OrderEventStore _orderEventStore;

    public OrderService(IDataContext context, OrderEventStore orderEventStore)
    {
        _appDataContext = context;
        _orderEventStore = orderEventStore;
    }

    public async ValueTask<Order> CreateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _appDataContext.Orders.AddAsync(order, cancellationToken);

        if (saveChanges) await _appDataContext.Orders.SaveChangesAsync(cancellationToken);

        await _orderEventStore.CreateOrderCreatedEvent(order);

        return order;
    }

    public async ValueTask<Order> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundOrder = await GetByIdAsync(id);

        await _appDataContext.Orders.RemoveAsync(foundOrder, cancellationToken);

        if (saveChanges) await _appDataContext.Orders.SaveChangesAsync(cancellationToken);

        return foundOrder;
    }

    public async ValueTask<Order> DeleteAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync(order.Id, saveChanges, cancellationToken);
    }

    public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
    {
        return _appDataContext.Orders.Where(predicate.Compile()).AsQueryable();
    }

    public ValueTask<ICollection<Order>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        var orders = _appDataContext.Orders.Where(order => ids.Contains(order.Id));
        return new ValueTask<ICollection<Order>>(orders.ToList());
    }

    public ValueTask<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var foundOrder = _appDataContext.Orders.FirstOrDefault(order => order.Id == id);
        if (foundOrder == null)
            throw new ArgumentException();

        return new ValueTask<Order>(foundOrder);
    }

    public async ValueTask<Order> UpdateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundOrder = await GetByIdAsync(order.Id, cancellationToken);

        foundOrder.Amount = order.Amount;

        if (saveChanges) await _appDataContext.Orders.SaveChangesAsync(cancellationToken);

        return foundOrder;
    }
}