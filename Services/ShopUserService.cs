using Merchant_API.models;

namespace Merchant_API.services;

public class ShopUserService{

    /// ctor
    public ShopUserService()
    {
        
    }


///Default Values
    private List<ShopUser> ShopUsers = new List<ShopUser> () {
        new ShopUser("1", "username1", "Profile Picture1","Phone Number1","Email1","Address1","Zipcode", "Password","Buyer", false)
    };

/// Create Method
public async Task CreateAsynce (ShopUser newShopUser){
    ShopUsers.Add(newShopUser);
}

/// Get all method
public async Task<List<ShopUser>> GetAsync(){
    return ShopUsers;
}

/// get one method
public async Task<ShopUser> GetAsync( string Id){

    return ShopUsers.Find(x => x.Id == Id);
}
/// Update method
public async Task<bool> UpdateAsync (string Id, ShopUser UpdatedShopUser){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
        UpdatedShopUser.Id = Id;
        ShopUsers[index]= UpdatedShopUser;
        result=true;
    }

    return result;

}



/// Detele method
public async Task<bool> DeleteAsync(string Id){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
        ShopUsers.RemoveAt(index);
        result=true;
    }

    return result;

}

/// AddItem method
public async Task<bool> Update2Async (string Id, ShopUser UpdatedShopUser){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
        UpdatedShopUser.Id = Id;
        ShopUsers[index]= UpdatedShopUser;
        result=true;
    }

    return result;

}
}
