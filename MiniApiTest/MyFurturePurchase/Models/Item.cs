using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MyFurturePurchase.Models
{
    public class Item
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid? Id { get; set; }
        [BsonElement("Name")]
        public required string ItemName { get; set; }
        public decimal Price { get; set; }
        public string? Location { get; set; }


    }
}