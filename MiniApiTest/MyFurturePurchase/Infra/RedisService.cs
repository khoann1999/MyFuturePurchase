
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MyFurturePurchase.Infra
{
    public class RedisService(IConfiguration IConfiguration) : ICacheService
    {
        private readonly IDatabase _redis = ConnectionMultiplexer.Connect(IConfiguration.GetConnectionString("RedisConnectionString")!).GetDatabase();

        public async Task<T?> GetAsync<T>(string key)
        {
            if (key is null) return default;
            var json = await _redis.StringGetAsync(key);
            if (!string.IsNullOrEmpty(json))
            {
                T? result = JsonConvert.DeserializeObject<T>(json.ToString());
                return result;
            }
            return default;
        }

        public async void SetAsync(string key, object inValue)
        {
            if (string.IsNullOrEmpty(key)) return;
            if (inValue is null) return;
            var setTask = _redis.StringSetAsync(key, JsonConvert.SerializeObject(inValue));
            var expireTask = _redis.KeyExpireAsync(key, TimeSpan.FromMinutes(1));
            await Task.WhenAll(setTask, expireTask);
        }

    }

}