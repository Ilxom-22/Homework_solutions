using Caching.Api.Data;
using Caching.Application.Common.Identity.Services;
using Caching.Infrastructure.Common.Caching.Brokers;
using Caching.Infrastructure.Common.Identity.Services;
using Caching.Infrastructure.Common.Settings;
using Caching.Persistence.Caching.Brokers;
using Caching.Persistence.DataContexts;
using Caching.Persistence.Repositories;
using Caching.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Caching.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    {
        // register cache settings
        builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));

        // register distributed cache (redis)
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetConnectionString("RedisConnectionString");
            options.InstanceName = "Caching.SimpleInfra";
        });

        // register redis cache broker
        builder.Services.AddSingleton<ICacheBroker, RedisDistributedCacheBroker>();

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        // register db context
        builder.Services.AddDbContext<IdentityDbContext>(options => 
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // register repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        // register foundation data access services
        builder.Services.AddScoped<IUserService, UserService>();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static async ValueTask<WebApplication> SeedDataAsync(this WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();

        await serviceScope.ServiceProvider.InitializeSeedAsync();

        return app;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}