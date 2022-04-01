namespace Merchant_API.models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

public class ShopUser{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    public string ProfilePicture { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Zipcode { get; set; }
    public string Password { get; set; }
    public bool IsBuyer { get; set; }
    public bool IsLoggedIn { get; set; }
    public List<ShopItem> ShoppingBag { get; set; }
    public List<List<ShopItem>> OrderHistory { get; set; }
    // public List<Tuple<List<ShopItem>,string>> OrderHistory { get; set; }

    public ShopUser (string Id, string Name,string ProfilePicture, string PhoneNumber,
    string Email, string Address,string Zipcode, string Password,bool IsBuyer, bool IsLoggedIn)
    {
        this.Id = Id;
        this.Name = Name;
        this.ProfilePicture = ProfilePicture;
        this.PhoneNumber = PhoneNumber;
        this.Email = Email;
        this.Address = Address;
        this.Zipcode = Zipcode;
        this.Password = Password;
        this.IsBuyer= IsBuyer;
        this.IsLoggedIn = IsLoggedIn;
        this.ShoppingBag = new List<ShopItem>();
        this.OrderHistory =  new List<List<ShopItem>>();
        
        //this.OrderHistory =  new List<Tuple<List<ShopItem>, string>>();
       

        //this.ShoppingBag = new List<ShopItem>();
        //this.ShoppingBag.add(ShoppingBag);


        
    }
}