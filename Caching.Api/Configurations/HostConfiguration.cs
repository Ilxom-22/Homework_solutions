namespace Caching.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddIdentityInfrastructure()
            .AddCaching()
            .AddExposers()
            .AddDevTools();

        return new(builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseExposers().UseDevTools();
        await app.SeedDataAsync();

        return app;
    }
}