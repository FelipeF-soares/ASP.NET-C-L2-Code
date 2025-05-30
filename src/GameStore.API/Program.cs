using GameStore.Application.Services;
using GameStore.Application.Services.Interfaces;
using GameStore.Infrastructure.ApplicationContext;
using GameStore.Infrastructure.GameStorePersistence;
using GameStore.Infrastructure.GameStorePersistence.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<GameStoreDbContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<IGameStoreGeneralPersist, GameStoreGeneralPersist>();
builder.Services.AddScoped<IGameStoreOrderPersist, GameStoreOrderPersist>();
builder.Services.AddScoped<IGameStoreBoxPersist, GameStoreBoxPersist>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IBoxService, BoxService>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(json =>
    {
        json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();
    db.Database.Migrate();
}


if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
