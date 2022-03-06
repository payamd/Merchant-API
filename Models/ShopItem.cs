namespace Merchant_API.models;

public class ShopItem{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public string Price { get; set; }
    public string Option { get; set; }
    public string Category { get; set; }

    public string Quantity { get; set; }

    public ShopItem (int Id, string Name, string ShortDescription,
    string Description, string Picture,string Price, string Option, string Category, string Quantity)
    {
        this.Id = Id;
        this.Name = Name;
        this.ShortDescription = ShortDescription;
        this.Description = Description;
        this.Picture = Picture;
        this.Price = Price;
        this.Option = Option;
        this.Category = Category;
        this.Quantity = Quantity;

        
    }
}