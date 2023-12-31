﻿using Library.Api.Filters;
using Library.Application.Common.Entity;
using Library.Domain.Entities;
using Library.Infrastructure.Common.Foundations;
using Library.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Library.Api.Configurations;

public static partial class HostConfiguration
{
    public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        return builder;
    }

    public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(configs => configs.Filters.Add<ExceptionFilter>());
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        return builder;
    }

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IEntityBaseService<Author>, AuthorService>()
            .AddScoped<IEntityBaseService<Book>, BookService>();

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