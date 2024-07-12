using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Entities;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ITodoService _toDoService;

        public ToDoController(ITodoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<List<ToDo>> Get()
        => await _toDoService.GetToDosAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var toDo = await _toDoService.GetToDosAsync(id);

            if (toDo == null)
            {
                return NotFound();
            }

            return Ok(toDo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDo toDo)
        {
            await _toDoService.CreateAsync(toDo);
            return Ok(toDo);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(Guid id, ToDo toDo)
        {
            var toDoId = await _toDoService.GetToDosAsync(id);

            if (toDoId == null)
            {
                return NotFound();
            }

            await _toDoService.UpdateAsync(id, toDo);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(Guid id){
            await _toDoService.RemoveAsync(id);
            return NoContent();
        }
    }
}