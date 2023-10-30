using FileBaseContext.Context.Models.Configurations;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Notification.Services;
using Identity.Application.Common.Settings;
using Identity.Application.Foundations;
using Identity.Domain.Entities;
using Identity.Infrastructure.Common.Identity.Services;
using Identity.Infrastructure.Common.Notification.Services;
using Identity.Infrastructure.Foundations;
using Identity.Persistence.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Identity.Api.Configurations;

public static partial class HostConfiguration
{
    public static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
        builder.Services.Configure<VerificationTokenSettings>(builder.Configuration.GetSection(nameof(VerificationTokenSettings)));

        builder.Services
            .AddTransient<IPasswordHasherService, PasswordHasherService>()
            .AddTransient<IAccessTokenGeneratorService, AccessTokenGeneratorService>()
            .AddTransient<IVerificationCodeGeneratorService, VerificationTokenGeneratorService>()
            .AddTransient<IVerificationCodeGeneratorService, VerificationPasswordGeneratorService>()
            .AddTransient<IIdentityVerificationService, IdentityVerificationService>();

        builder.Services
            .AddScoped<IEntityBaseService<User>, UserService>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IEntityBaseService<VerificationCode>, VerificationCodeService>();

        var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = jwtSettings.ValidAudience,
                    ValidateLifetime = jwtSettings.ValidateLifetime,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

        return builder;
    }

    public static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<EmailSenderSettings>(builder.Configuration.GetSection(nameof(EmailSenderSettings)));

        builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();

        return builder;
    }

    public static WebApplicationBuilder AddDataContextInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDataContext, AppFileContext>(provider =>
        {
            var contextOptions = new FileContextOptions<AppFileContext>
            {
                StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
            };

            var context = new AppFileContext(contextOptions);
            context.FetchAsync().AsTask().Wait();

            return context;
        });

        return builder;
    }

    public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        return builder;
    }

    public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

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

    public static WebApplication UseIdentityInfrastructure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}