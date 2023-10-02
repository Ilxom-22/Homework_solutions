using FileBaseContext.Context.Models.Configurations;
using First.Api.DataAccess;
using First.Api.Services;
using First.Api.Models;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddScoped<IEntityBase<User>, UserService>();
builder.Services.AddScoped<IEntityBase<Order>, OrderService>();
builder.Services.AddScoped<UserOrdersService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

await app.RunAsync();