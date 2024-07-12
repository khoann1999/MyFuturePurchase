using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
namespace ToDoApi.Entities
{
   public class ToDo
{
    [BsonId(IdGenerator = typeof(GuidGenerator))]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid Id { get; set; }
    [BsonElement("Title")]
    public required String Title { get; set; }
    public String? Content { get; set; }    

}
}