using Merchant_API.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Merchant_API.services;

public class MongoDBService {
    private readonly IMongoCollection<Shop> _shopCollection;
    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings){

    MongoClient client = new MongoClient(mongoDBSettings.Value.connectionURI);
    IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
    _shopCollection = database.GetCollection<Shop>(mongoDBSettings.Value.collectionName);
        
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
public async Task<bool> UpdateAsync (string Id, string MovieId){
    FilterDefinition<Shop> filter = Builders<Shop>.Filter.Eq("Id",Id);
    UpdateDefinition<Shop> update = Builders<Shop>.Update.AddToSet<string>("movieId", MovieId);
    await _shopCollection.UpdateOneAsync(filter, update);
return true;
}

 
/// Detele method
public async Task<bool> DeleteAsync(string Id){
    FilterDefinition<Shop> filter = Builders<Shop>.Filter.Eq("Id", Id);
    await _shopCollection.DeleteOneAsync(filter);
return true;

}







}