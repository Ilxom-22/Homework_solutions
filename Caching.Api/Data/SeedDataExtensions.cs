using Bogus;
using Caching.Domain.Entities;
using Caching.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Caching.Api.Data;

public static class SeedDataExtensions
{
    public static async ValueTask InitializeSeedAsync(this IServiceProvider serviceProvider)
    {
        var identityDbContext = serviceProvider.GetRequiredService<IdentityDbContext>();

        if (!await identityDbContext.Users.AnyAsync())
            await SeedUsersAsync(identityDbContext);
    }

    private static async ValueTask SeedUsersAsync(this IdentityDbContext dbContext)
    {
        var userFaker = new Faker<User>()
            .RuleFor(user => user.FirstName, faker => faker.Person.FirstName)
            .RuleFor(user => user.LastName, faker => faker.Person.LastName);

        await dbContext.Users.AddRangeAsync(userFaker.Generate(10000));
        await dbContext.SaveChangesAsync(); 
    }
}