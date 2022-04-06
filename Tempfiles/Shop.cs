using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Merchant_API.models;

public class Shop{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string username {get;  set; } = null!;
    

    [BsonElement("items")]
    [JsonPropertyName("items")]
    public List<string> items {get; set;} = null!;

}