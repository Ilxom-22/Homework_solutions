using EfCore.Interceptors.Application.Common.Identity.Services;
using EfCore.Interceptors.Application.Common.RequestContexts.Brokers;
using EfCore.Interceptors.Domain.Brokers;
using EfCore.Interceptors.Infrastructure.Common.Services;
using EfCore.Interceptors.Infrastructure.RequestContexts.Brokers;
using EfCore.Interceptors.Infrastructure.Settings;
using EfCore.Interceptors.Persistence.DataContexts;
using EfCore.Interceptors.Persistence.Interceptors;
using EfCore.Interceptors.Persistence.Repositories;
using EfCore.Interceptors.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EfCore.Interceptors.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<UpdateAuditableInterceptor>()
            .AddScoped<UpdatePrimaryKeyInterceptor>()
            .AddScoped<UpdateSoftDeletionInterceptor>();

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        // register db contexts
        builder.Services.AddDbContext<IdentityDbContext>(
            (provider, options) =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

                options.AddInterceptors(provider.GetRequiredService<UpdatePrimaryKeyInterceptor>());
                options.AddInterceptors(provider.GetRequiredService<UpdateAuditableInterceptor>());
                options.AddInterceptors(provider.GetRequiredService<UpdateSoftDeletionInterceptor>());
            }
        );

        // register repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        // register foundation data access services
        builder.Services.AddScoped<IUserService, UserService>();

        return builder;
    }

    private static WebApplicationBuilder AddRequestContextTools(this WebApplicationBuilder builder)
    {
        // register request settings
        builder.Services.Configure<RequestUserContextSettings>(builder.Configuration.GetSection(nameof(RequestUserContextSettings)));

        // register http context accessor
        builder.Services.AddHttpContextAccessor();

        // register request contexts
        builder.Services
            .AddScoped<IRequestContextProvider, RequestContextProvider>()
            .AddScoped<IRequestUserContextProvider, RequestUserContextProvider>();

        return builder;
    }

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        // register automapper
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}