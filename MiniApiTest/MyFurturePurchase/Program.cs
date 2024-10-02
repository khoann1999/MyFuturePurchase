using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MyFurturePurchase.Context;
using MyFurturePurchase.Infra;
using MyFurturePurchase.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoClient = new MongoClient(builder.Configuration.GetConnectionString("ConnectionString"));

builder.Services.AddDbContext<MyDBContext>(db => db.UseMongoDB(mongoClient, builder.Configuration.GetConnectionString("DatabaseName")!));
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddSingleton<ICacheService, RedisService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();