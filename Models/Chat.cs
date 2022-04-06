namespace Merchant_API.models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
public class Chat{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
     public string Name { get; set; }
    public string Content { get; set; }
    public string Date { get; set; }
    public Chat(){
        
    }
        public Chat (string Id,string Name,string Content)
        : this()
    {
        this.Id = Id;
        this.Name = Name;
        this.Content = Content;
        this.Date = DateTime.Now.ToString(); 
    }

    public Chat (string Id,string Name,string Content, string Date)
    : this()
    {
        this.Id = Id;
        this.Name = Name;
        this.Content = Content;
        this.Date = Date;
 
    }

}