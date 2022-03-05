namespace Merchant_API.models;

public class ShopUser{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ProfilePicture { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Zipcode { get; set; }
    public string Password { get; set; }
    public string ShopUserRole { get; set; }
    public bool Authorize { get; set; }
    public List<ShopItem> ShoppingBag { get; set; }

    public ShopUser (string Id, string Name,string ProfilePicture, string PhoneNumber,
    string Email, string Address,string Zipcode, string Password,string ShopUserRole, bool Authorize)
    {
        this.Id = Id;
        this.Name = Name;
        this.ProfilePicture = ProfilePicture;
        this.PhoneNumber = PhoneNumber;
        this.Email = Email;
        this.Address = Address;
        this.Zipcode = Zipcode;
        this.Password = Password;
        this.ShopUserRole= ShopUserRole;
        this.Authorize = Authorize;
        this.ShoppingBag = new List<ShopItem>();
        //this.ShoppingBag.add(ShoppingBag);


        
    }
}