using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MyFurturePurchase.Context;
using MyFurturePurchase.Models;

namespace MyFurturePurchase.Services
{
    public class ItemService : IItemService
    {
        private readonly MyDBContext _myDBContext;

        public ItemService(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }
        public async Task InsertItemAsync(Item item)
        {
            item.Id = Guid.NewGuid();
            await _myDBContext.Items.AddAsync(item);
            await _myDBContext.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var item = await _myDBContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                _myDBContext.Items.Remove(item);
            }
            await _myDBContext.SaveChangesAsync();

        }

        public async Task<Item?> GetItemAsync(Guid id)
        => await _myDBContext.Items.FirstOrDefaultAsync(item => item.Id == id);


        public async Task<List<Item>> GetItemsAsync()
        => await _myDBContext.Items.OrderBy(item => item.Id).ToListAsync();

        public async Task UpdateItemAsync(Item item)
        {
            _myDBContext.Items.Update(item);
            await _myDBContext.SaveChangesAsync();

        }
    }


}