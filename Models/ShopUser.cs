namespace Merchant_API.models;

public class ShopUser{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProfilePicture { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Zipcode { get; set; }
    public string Password { get; set; }
    public bool IsBuyer { get; set; }
    public bool IsLoggedIn { get; set; }
    public List<int> ShoppingBag { get; set; }

    //public List<ShopItem> ShoppingBag { get; set; }

    public ShopUser (int Id, string Name,string ProfilePicture, string PhoneNumber,
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
        this.ShoppingBag = new List<int>();
        //this.ShoppingBag = new List<ShopItem>();
        //this.ShoppingBag.add(ShoppingBag);


        
    }
}