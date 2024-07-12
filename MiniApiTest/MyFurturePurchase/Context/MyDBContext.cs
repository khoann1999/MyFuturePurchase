using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using MyFurturePurchase.Models;

namespace MyFurturePurchase.Context
{
    public class MyDBContext : DbContext
    {
        public DbSet<Item> Items { get; init; }
        public static MyDBContext Create(IMongoDatabase database) =>
    new(new DbContextOptionsBuilder<MyDBContext>()
        .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
        .Options);
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().ToCollection("Item");
        }
    }
}