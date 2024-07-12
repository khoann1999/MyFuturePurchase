
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ToDoApi.Entities;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class ToDoService : ITodoService
    {
        private IMongoCollection<ToDo> _ToDoCollection;
        public ToDoService(IOptions<MyDBSetting> options){
            var MyDBClient = new MongoClient(options.Value.ConnectionString);

            var MyDBLabDatabase = MyDBClient.GetDatabase(options.Value.DatabaseName);

            _ToDoCollection = MyDBLabDatabase.GetCollection<ToDo>(options.Value.ToDoCollectionName);
        }

       public async Task<List<ToDo>> GetToDosAsync()
        => await _ToDoCollection.Find(_ => true).ToListAsync();

        public async Task<ToDo?> GetToDosAsync(Guid Id)
        => await _ToDoCollection.Find(item => item.Id == Id).FirstOrDefaultAsync();

        public async Task CreateAsync(ToDo newToDo)
        => await _ToDoCollection.InsertOneAsync(newToDo);

        public async Task UpdateAsync(Guid id, ToDo updatedToDo)
        => await _ToDoCollection.ReplaceOneAsync(item => item.Id == id, updatedToDo);

        public async Task RemoveAsync(Guid Id)
        => await _ToDoCollection.DeleteOneAsync(item => item.Id == Id);
    }
}