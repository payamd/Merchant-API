using Merchant_API.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Merchant_API.services;

public class ShopServiceold {
    private readonly IMongoCollection<Shop> _shopCollection;
    public ShopServiceold(IOptions<MongoDBSettings> mongoDBSettings){

   // MongoClient client = new MongoClient(mongoDBSettings.Value.connectionURI);
   // IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
   // _shopCollection = database.GetCollection<Shop>(mongoDBSettings.Value.collectionName);
               var settings = MongoClientSettings.FromConnectionString(mongoDBSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _shopCollection = database.GetCollection<Shop>(mongoDBSettings.Value.ShopCollectionName); 
    }




/// Create Method
public async Task CreateAsynce (Shop shop){
    await _shopCollection.InsertOneAsync(shop); 
}

/// Get all method
public async Task<List<Shop>> GetAsync(){
    return await _shopCollection.Find(new BsonDocument()).ToListAsync(); 

}

// /// get one method
// public async Task<Shop> GetAsync( string Id){
//   return 1;  
// }
/// Update method
public async Task<bool> UpdateAsync (string Id, string item){
    FilterDefinition<Shop> filter = Builders<Shop>.Filter.Eq("Id",Id);
    //UpdateDefinition<Shop> update = Builders<Shop>.Update.AddToSet<string>("items", item);
    UpdateDefinition<Shop> update = Builders<Shop>.Update.AddToSet<string>("items", item);
    await _shopCollection.UpdateOneAsync(filter, update);
return true;
}

/// Update2 method
public async Task<bool> Update2Async (string Id, Shop updatedshop){
        ReplaceOneResult r = await _shopCollection.ReplaceOneAsync(Shop => Shop.Id == updatedshop.Id, updatedshop);
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
}

 
/// Detele method
public async Task<bool> DeleteAsync(string Id){
    FilterDefinition<Shop> filter = Builders<Shop>.Filter.Eq("Id", Id);
    await _shopCollection.DeleteOneAsync(filter);
return true;

}



}


    
    //"ConnectionURI":"mongodb+srv://payam:P123123123@merchant.wjtth.mongodb.net/myFirstDatabase?retryWrites=true&w=majority",
    //"DatabaseName":"Merchant_Mongo",
    //"CollectionName":"Shop"