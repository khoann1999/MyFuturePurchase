using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Entities;

namespace ToDoApi.Services
{
    public interface ITodoService
    {
        public Task<List<ToDo>> GetToDosAsync();
        public Task<ToDo?> GetToDosAsync(Guid Id);
        public Task CreateAsync(ToDo newToDo);
        public Task UpdateAsync(Guid id, ToDo updatedToDo);
        public Task RemoveAsync(Guid Id);
    
    }
}