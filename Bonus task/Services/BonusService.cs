using Bonus_task.Interfaces;
using Bonus_task.Models;
using Bonus_Task.DataAccess;
using System.Linq.Expressions;

namespace Bonus_task.Services;

public class BonusService : IEntityBaseService<Bonus>
{
    private readonly IDataContext _dataContext;

    public BonusService(IDataContext context)
    {
        _dataContext = context;
    }

    public async ValueTask<Bonus> CreateAsync(Bonus bonus, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dataContext.Bonuses.AddAsync(bonus, cancellationToken);

        if (saveChanges) await _dataContext.SaveChangesAsync();

        return bonus;
    }

    public ValueTask<ICollection<Bonus>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        var bonuses = _dataContext.Bonuses.Where(bonus => ids.Contains(bonus.Id));
        return new ValueTask<ICollection<Bonus>>(bonuses.ToList());
    }

    public ValueTask<Bonus> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bonus = _dataContext.Bonuses.FirstOrDefault(self => self.Id == id);

        if (bonus == null)
            throw new ArgumentException();

        return new ValueTask<Bonus>(bonus);
    }

    public IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate)
    {
        return _dataContext.Bonuses.Where(predicate.Compile()).AsQueryable();
    }

    public async ValueTask<Bonus> UpdateAsync(Bonus bonus, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundBonus = await GetByIdAsync(bonus.Id, cancellationToken);

        foundBonus.Amount = bonus.Amount;

        if (saveChanges) await _dataContext.SaveChangesAsync();

        return foundBonus;
    }

    public async ValueTask<Bonus> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundBonus = await GetByIdAsync(id, cancellationToken);

        await _dataContext.Bonuses.RemoveAsync(foundBonus);

        if (saveChanges) await _dataContext.SaveChangesAsync();

        return foundBonus;
    }

    public async ValueTask<Bonus> DeleteAsync(Bonus bonus, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync(bonus.Id, saveChanges, cancellationToken);
    }
}