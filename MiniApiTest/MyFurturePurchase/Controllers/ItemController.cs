using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFurturePurchase.Context;
using MyFurturePurchase.Infra;
using MyFurturePurchase.Models;
using MyFurturePurchase.Services;
using StackExchange.Redis;


namespace MyFurturePurchase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController(IItemService itemService, ILogger<ItemController> logger, ICacheService cache) : ControllerBase
    {
        private readonly IItemService _itemService = itemService;
        private readonly ILogger<ItemController> _logger = logger;

        private readonly ICacheService _cache = cache;

        [HttpGet]
        public async Task<List<Item>> Get()
        => await _itemService.GetItemsAsync();
        [HttpGet("Redis/{id}")]
        public async Task<Item?> GetWithRedis(Guid id)
        {
            var result = await _cache.GetAsync<Item>(Convert.ToString(id)!);
            if (result is not null) return result;
            result = await _itemService.GetItemAsync(id);
            _cache.SetAsync(Convert.ToString(id)!, result!);
            return result;
        }
         [HttpGet("{id}")]
        public async Task<Item?> GetNormal(Guid id)
        {
            var result = await _cache.GetAsync<Item>(Convert.ToString(id)!);
            if (result is not null) return result;
            result = await _itemService.GetItemAsync(id);
            _cache.SetAsync(Convert.ToString(id)!, result!);
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            await _itemService.InsertItemAsync(item);
            return Ok(item);
        }
    }
}