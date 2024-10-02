using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyFurturePurchase.BenchMarkApp
{
    public class RestClient
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<object?> GetItemAsync(string id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await client.GetFromJsonAsync<object>($"http://localhost:5213/api/Item/{id}");
        }
         public async Task<object?> GetItemRedisAsync(string id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await client.GetFromJsonAsync<object>($"http://localhost:5213/api/Item/Redis/{id}");
        }
    }
}