using Bonus_task.CompositionServices;
using Bonus_task.Events;
using Bonus_task.Interfaces;
using Bonus_task.Models;
using Bonus_task.Services;
using Bonus_Task.DataAccess;
using FileBaseContext.Context.Models.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataContext, AppFileContext>(_ =>
{
    var contextOptions = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
    };

    var context = new AppFileContext(contextOptions);
    context.FetchAsync().AsTask().Wait();

    return context;
});

builder.Services
    .AddScoped<IEntityBaseService<User>, UserService>()
    .AddScoped<IEntityBaseService<Order>, OrderService>()
    .AddScoped<IEntityBaseService<Bonus>, BonusService>()
    .AddScoped<UserBonusService>()
    .AddScoped<UserPromotionService>()
    .AddScoped<UserOrdersService>();

builder.Services
    .AddSingleton<OrderEventStore>()
    .AddSingleton<BonusEventStore>()
    .AddSingleton<INotificationService, EmailSenderService>()
    .AddSingleton<INotificationService, SmsSenderService>()
    .AddSingleton<INotificationService, TelegramSenderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.CreateScope().ServiceProvider.GetRequiredService<UserBonusService>();
app.Services.CreateScope().ServiceProvider.GetService<UserPromotionService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
