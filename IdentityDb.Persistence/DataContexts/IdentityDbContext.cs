using IdentityDb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityDb.Persistence.DataContexts;

public class IdentityDbContext : DbContext
{
    public DbSet<Role> Roles => Set<Role>();

    public DbSet<User> Users => Set<User>();

    public DbSet<AccessToken> AccessTokens => Set<AccessToken>();


    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
}