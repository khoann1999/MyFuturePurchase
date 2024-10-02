using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
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
        [JsonPropertyName("Name")]
        public required string ItemName { get; set; }
        [JsonPropertyName("number")]
        public decimal Price { get; set; }
        [JsonPropertyName("Location")]
        public string? Location { get; set; }

        public static implicit operator Item(List<Item> v)
        {
            throw new NotImplementedException();
        }
    }
}