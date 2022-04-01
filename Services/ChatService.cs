namespace Merchant_API.services;
using Merchant_API.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

public class ChatService{

    private readonly IMongoCollection<Chat> _chatCollection;
    /// ctor
    public ChatService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        var settings = MongoClientSettings.FromConnectionString(mongoDBSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _chatCollection = database.GetCollection<Chat>(mongoDBSettings.Value.ChatCollectionName);
    
        
    }


///Default Values
    private List<Chat> Chats = new List<Chat> () {
        new Chat(1,"user1", "I have a question!", "2022"),
        new Chat(2, "user2", "I have a question!", "2021")
    };


/// Get all method
public async Task<List<Chat>> GetAsync(){
    return Chats;
}

/// Get one method
public async Task<Chat> GetAsync( int Id){

    return Chats.Find(x => x.Id == Id);
}

/// Create Method with Json
public async Task CreateAsynce (Chat newChat){
   Chats.Add(newChat);
}


/// Create Method with keys
public async Task CreatewithkeysAsynce (string Name,string Content){
    int id = Chats.Count();
    id = id+1;
    Chat newmessage = new Chat(id,Name,Content);
    Chats.Add(newmessage);
}



/// Detele method
public async Task<bool> DeleteAsync(int Id){
    bool result = false;
    int index = Chats.FindIndex(x=> x.Id == Id);
    if (index != -1){
        Chats.RemoveAt(index);
        result=true;
    }

    return result;

}

}
