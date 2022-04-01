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
    // private List<Chat> Chats = new List<Chat> () {
    //     new Chat("1","user1", "I have a question!", "2022"),
    //     new Chat("2", "user2", "I have a question!", "2021")
    // };


/// Get all method
public async Task<List<Chat>> GetAsync(){
        return await _chatCollection.Find(_ => true).ToListAsync();
}

/// Get one method
public async Task<Chat> GetAsync( string Id){

        return await _chatCollection.Find<Chat>(chat => chat.Id == Id).FirstOrDefaultAsync();

}

/// Create Method with Json
public async Task CreateAsynce (Chat newChat){
        newChat.Id = null; // will be set by Mongo
        await _chatCollection.InsertOneAsync(newChat);
}


/// Create Method with keys
public async Task CreatewithkeysAsynce (string Name,string Content){
    //int id = Chats.Count();
    //id = id+1;
     Chat newmessage=  new Chat();
     newmessage.Id = null;
     newmessage.Name= Name;
     newmessage.Content=Content;
     newmessage.Date = DateTime.Now.ToString();
    //Chats.Add(newmessage);
    await _chatCollection.InsertOneAsync(newmessage);
}



/// Detele method
public async Task<bool> DeleteAsync(string Id){
        DeleteResult r = await _chatCollection.DeleteOneAsync(chat => chat.Id == Id);
        return r.DeletedCount == 1;
    // bool result = false;
    // int index = Chats.FindIndex(x=> x.Id == Id);
    // if (index != -1){
    //     DeleteResult r = await _chatCollection.DeleteOneAsync(chat => chat.Id == Id);
    //     result=true;
    //     return r.DeletedCount == 1;
    // }

    // return result;

}

}
