using LearningCenter.Application.Common.Identity.Services;
using LearningCenter.Application.Common.Location;
using LearningCenter.Application.Courses.Services;
using LearningCenter.Infrastructure.Common.Identity.Services;
using LearningCenter.Infrastructure.Courses.Services;
using LearningCenter.Infrastructure.Location;
using LearningCenter.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Api.Configurations;

public static partial class HostConfigurations
{
    public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        return builder;
    }

    public static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IUserSettingsService, UserSettingsService>()
            .AddScoped<IUserRoleService, UserRoleService>();

        return builder;
    }

    public static WebApplicationBuilder AddCoursesInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICourseService, CourseService>();

        return builder;
    }

    public static WebApplicationBuilder AddLocationsInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ILocationService, LocationService>();

        return builder;
    }

    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString"));
        });

        return builder;
    }
    
    public static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    public static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}