namespace Merchant_API.models;
public class MongoDBSettings{
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? ShopCollectionName { get; set; }
        public string? ChatCollectionName { get; set; }
        public string? ItemCollectionName { get; set; }
        public string? UserCollectionName { get; set; }



public MongoDBSettings()
{
    this.ConnectionString = "mongodb://payam:P123123123@merchant-shard-00-00.08y6e.mongodb.net:27017,merchant-shard-00-01.08y6e.mongodb.net:27017,merchant-shard-00-02.08y6e.mongodb.net:27017/myFirstDatabase?ssl=true&replicaSet=atlas-tgydkl-shard-0&authSource=admin&retryWrites=true&w=majority";
    this.DatabaseName= "Merchant";
    this.ShopCollectionName="Shop";
    this.ChatCollectionName="Chat";
    this.ItemCollectionName="Item";
    this.UserCollectionName="User";
}
}