using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFurturePurchase.Models;
using StackExchange.Redis;

namespace MyFurturePurchase.Infra
{
    public interface ICacheService
    {
        public Task<T?> GetAsync<T>(string key);
        public void SetAsync(string key, object inValue);

    }
}