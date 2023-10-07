using Empty_web_API_project.DataAccess;
using Empty_web_API_project.Models;
using Empty_web_API_project.Services;
using FileBaseContext.Context.Models.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDataContext, AppFileContext>(_ =>
{
    var contextOptions = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "Storage")
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