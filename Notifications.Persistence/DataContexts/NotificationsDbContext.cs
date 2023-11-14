using Microsoft.EntityFrameworkCore;
using Notifications.Domain.Entities;

namespace Notifications.Persistence.DataContexts;

public class NotificationsDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public NotificationsDbContext(DbContextOptions contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationsDbContext).Assembly);
}