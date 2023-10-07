using Empty_web_API_project.DataAccess;
using Empty_web_API_project.Models;
using System.Linq.Expressions;

namespace Empty_web_API_project.Services;

public class OrderService : IEntityBase<Order>
{
    private readonly IDataContext _appDataContext;

    public OrderService(IDataContext context)
    {
        _appDataContext = context;
    }

    public async ValueTask<Order> CreateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _appDataContext.Orders.AddAsync(order, cancellationToken);

        if (saveChanges) await _appDataContext.Orders.SaveChangesAsync(cancellationToken);

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
        var foundOrder =  _appDataContext.Orders.FirstOrDefault(order => order.Id == id);
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