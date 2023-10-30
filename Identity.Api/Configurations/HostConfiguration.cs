namespace Identity.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddDataContextInfrastructure()
            .AddIdentityInfrastructure()
            .AddNotificationInfrastructure()
            .AddExposers()
            .AddDevTools();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseIdentityInfrastructure()
            .UseExposers()
            .UseDevTools();

        return new(app);
    }
}