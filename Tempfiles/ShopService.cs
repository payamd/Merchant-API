using Merchant_API.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Merchant_API.services;

public class ShopService {
    private readonly IMongoCollection<Shop> _shopCollection;
    public ShopService(IOptions<MongoDBSettings> mongoDBSettings){

   //MongoClient client = new MongoClient(mongoDBSettings.Value.connectionURI);
    //IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
    //_shopCollection = database.GetCollection<Shop>(mongoDBSettings.Value.collectionName);
        var settings = MongoClientSettings.FromConnectionString(mongoDBSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _shopCollection = database.GetCollection<Shop>(mongoDBSettings.Value.ShopCollectionName);
    }




/// Create Method
public async Task CreateAsynce (Shop newShop){
        newShop.Id = null; // will be set by Mongo
        await _shopCollection.InsertOneAsync(newShop);
}

/// Get all method
public async Task<List<Shop>> GetAsync(){
    return await _shopCollection.Find(_ => true).ToListAsync();

}

// /// get one method
    public async Task<Shop> GetAsync(string Id) {
    return await _shopCollection.Find<Shop>(Shop => Shop.Id == Id).FirstOrDefaultAsync();
    }


/// Update method
public async Task<bool> UpdateAsync (string Id, Shop updatedshop){
    ReplaceOneResult r = await _shopCollection.ReplaceOneAsync(Shop => Shop.Id == Id, updatedshop);
    return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
}

 
/// Detele method
public async Task<bool> DeleteAsync(string Id){
    DeleteResult r = await _shopCollection.DeleteOneAsync(Shop => Shop.Id == Id);
    return r.DeletedCount == 1;
}



}