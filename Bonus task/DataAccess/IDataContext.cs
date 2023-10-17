using FileBaseContext.Abstractions.Models.FileSet;
using Bonus_task.Models;


namespace Bonus_Task.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Order, Guid> Orders { get; }
    IFileSet<Bonus, Guid> Bonuses { get; }
    ValueTask SaveChangesAsync();
}
