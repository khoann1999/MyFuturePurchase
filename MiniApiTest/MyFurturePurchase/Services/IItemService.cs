using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFurturePurchase.Context;
using MyFurturePurchase.Models;

namespace MyFurturePurchase.Services
{
    public interface IItemService
    {
      
        public Task<Item?> GetItemAsync(Guid id);
        public Task<List<Item>> GetItemsAsync();
        public Task InsertItemAsync(Item newItem);
        public Task UpdateItemAsync(Item item);
        public Task DeleteItemAsync(Guid id);
    }
}