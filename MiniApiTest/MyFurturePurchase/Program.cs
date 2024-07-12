using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MyFurturePurchase.Context;
using MyFurturePurchase.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoClient = new MongoClient(builder.Configuration.GetConnectionString("ConnectionString"));
var databaseName = builder.Configuration.GetConnectionString("DatabaseName");
if (databaseName is not null)
{
    builder.Services.AddDbContext<MyDBContext>(db => db.UseMongoDB(mongoClient, databaseName));
    builder.Services.AddScoped<IItemService, ItemService>();
}

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
