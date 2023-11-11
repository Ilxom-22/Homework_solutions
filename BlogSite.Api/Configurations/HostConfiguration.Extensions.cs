using BlogSite.Application.Common.Foundations;
using BlogSite.Infrastructure.Common.Foundations;
using BlogSite.Persistence.DataContexts;
using BlogSite.Persistence.Repositories;
using BlogSite.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        return builder;
    }

    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IRoleService, RoleService>();

        return builder;
    }

    private static WebApplicationBuilder AddContentInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IBlogRepository, BlogRepository>()
            .AddScoped<IBlogService, BlogService>();

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