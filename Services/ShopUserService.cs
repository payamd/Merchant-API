using Merchant_API.models;

namespace Merchant_API.services;

public class ShopUserService{

    /// ctor
    public ShopUserService()
    {
        
    }


///Default Values
    private List<ShopUser> ShopUsers = new List<ShopUser> () {
        new ShopUser(1, "username1", "Profile Picture1","Phone Number1","Email1","Address1","Zipcode", "Password",true, false),
        new ShopUser(2, "username2", "Profile Picture2","Phone Number2","Email2","Address2","Zipcode", "Password",false, false)
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
public async Task<List<ShopUser>> GetAsync( int Id){

    List<ShopUser> List1 = new List<ShopUser>();
    List1.Add(ShopUsers.Find(x => x.Id == Id));
    return List1;
}
/// Update method
public async Task<bool> UpdateAsync (int Id, ShopUser UpdatedShopUser){
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
public async Task<bool> DeleteAsync(int Id){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
        ShopUsers.RemoveAt(index);
        result=true;
    }

    return result;

}

/// AddItemtobag method
public async Task<bool> AddItemAsync (int Id , int itemId){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
//        UpdatedShopUser.Id = Id;
        ShopUsers[index].ShoppingBag.Add(itemId);
        result=true;
    }

    return result;

}


/// removeItemfrombag method
public async Task<bool> RemoveItemAsync (int Id , int itemId){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
//        UpdatedShopUser.Id = Id;
    int itemindex = ShopUsers[index].ShoppingBag.FindIndex(x=> x == itemId);

     if (itemindex != -1){
        ShopUsers[index].ShoppingBag.RemoveAt(itemindex);
        result=true;}
    }

    return result;

}

/// login method
public async Task<bool> LoginAsync (int Id , string Email, string Password){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
        if( ShopUsers[index].Email == Email && ShopUsers[index].Password == Password ){
        ShopUsers[index].IsLoggedIn = true;
        result=true;}
        }
    return result;

}

/// logout method
public async Task<bool> LogoutAsync (int Id){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
        ShopUsers[index].IsLoggedIn = false;
        result=true;} 
    return result;

}



}
