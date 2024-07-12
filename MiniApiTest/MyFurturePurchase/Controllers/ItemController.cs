using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFurturePurchase.Context;
using MyFurturePurchase.Models;
using MyFurturePurchase.Services;


namespace MyFurturePurchase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;
        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<List<Item>> Get()
        => await _itemService.GetItemsAsync();
        [HttpGet("{id:length(24)}")]
        public async Task<List<Item>> Get(Guid id)
        => await _itemService.GetItemsAsync(id);
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            await _itemService.InsertItemAsync(item);
            return Ok(item);
        }
    }
}