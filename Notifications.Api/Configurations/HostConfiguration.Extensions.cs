using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notifications.Application.Common.Notifications.Brokers;
using Notifications.Application.Common.Notifications.Services;
using Notifications.Infrastructure.Common.Notifications.Brokers;
using Notifications.Infrastructure.Common.Notifications.Services;
using Notifications.Persistence.DataContexts;
using Notifications.Persistence.Repositories;
using Notifications.Persistence.Repositories.Interfaces;
using System.Reflection;

namespace Notifications.Api.Configurations;

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

    private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {
        var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        assemblies.Add(Assembly.GetExecutingAssembly());

        builder.Services.AddValidatorsFromAssemblies(assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddNotificationsInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<NotificationsDbContext>(options => options
            .UseNpgsql(builder.Configuration.GetConnectionString("NotificationsDbConnection")));

        builder.Services
            .AddScoped<ISmsTemplateRepository, SmsTemplateRepository>()
            .AddScoped<IEmailTemplateRepository, EmailTemplateRepository>()
            .AddScoped<ISmsHistoryRepository, SmsHistoryRepository>()
            .AddScoped<IEmailHistoryRepository, EmailHistoryRepository>();

        builder.Services
            .AddScoped<IEmailTemplateService, EmailTemplateService>()
            .AddScoped<ISmsTemplateService, SmsTemplateService>();

        builder.Services
            .AddScoped<ISmsSenderBroker, TwilioSmsSenderBroker>();

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