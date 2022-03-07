using Merchant_API.models;

namespace Merchant_API.services;

public class ShopItemService{

    /// ctor
    public ShopItemService()
    {
        
    }


///Default Values
    private List<ShopItem> ShopItems= new List<ShopItem> () {
        new ShopItem(1, "Item 1 name", "Short description","Long description","Picture","Price","Black","Books", "1"),
        new ShopItem(2, "Item 1 name", "Short description","Long description","Picture","Price","Black","Books", "1"),
        new ShopItem(3, "Item 1 name", "Short description","Long description","Picture","Price","Black","Foods", "1"),
        new ShopItem(4, "Item 1 name", "Short description","Long description","Picture","Price","Black","Foods", "1"),
        new ShopItem(5, "Item 1 name", "Short description","Long description","Picture","Price","Black","Foods", "1"),
        new ShopItem(6, "Item 1 name", "Short description","Long description","Picture","Price","Black","Books", "1"),
        new ShopItem(7, "Item 1 name", "Short description","Long description","Picture","Price","Black","Books", "1"),
        new ShopItem(8, "Item 1 name", "Short description","Long description","Picture","Price","Black","Books", "1"),
        new ShopItem(9, "Item 1 name", "Short description","Long description","Picture","Price","Black","Books", "1"),
        new ShopItem(10, "Item 1 name", "Short description","Long description","Picture","Price","Black","Books", "1")

    };

/// Create Method
public async Task CreateAsynce (ShopItem newShopItem){
    ShopItems.Add(newShopItem);
}

/// Get all method
public async Task<List<ShopItem>> GetAsync(){
    return ShopItems;
}

/// get one method
public async Task<ShopItem> GetAsync( int Id){

    return ShopItems.Find(x => x.Id == Id);
}
/// Update method
public async Task<bool> UpdateAsync (int Id, ShopItem UpdatedShopItem){
    bool result = false;
    int index = ShopItems.FindIndex(x=> x.Id == Id);
    if (index != -1){
        UpdatedShopItem.Id = Id;
        ShopItems[index]= UpdatedShopItem;
        result=true;
    }

    return result;

}


/// Detele method
public async Task<bool> DeleteAsync(int Id){
    bool result = false;
    int index = ShopItems.FindIndex(x=> x.Id == Id);
    if (index != -1){
        ShopItems.RemoveAt(index);
        result=true;
    }

    return result;

}





}