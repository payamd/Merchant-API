namespace Merchant_API.models;
public class MongoDBSettings{
    public string connectionURI {get; set;} = null!;
    
    public string DatabaseName  {get; set;} = null!;

    public string collectionName {get; set;} = null!;

}