﻿namespace EfCore.Interceptors.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddIdentityInfrastructure()
            .AddRequestContextTools()
            .AddPersistence()
            .AddMappers()
            .AddDevTools()
            .AddExposers();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevTools()
            .UseExposers()
            .UseIdentityInfrastructure();

        return new(app);
    }
}