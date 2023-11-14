using Microsoft.EntityFrameworkCore;

namespace Notifications.Persistence.DataContexts;

public class NotificationsDbContext : DbContext
{
    public NotificationsDbContext(DbContextOptions contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationsDbContext).Assembly);
}