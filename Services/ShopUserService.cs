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
/// Create user by keys Method
public async Task<bool> CreatebykeysAsynce (string Name,string ProfilePicture, string PhoneNumber,
    string Email, string Address,string Zipcode, string Password,bool IsBuyer){
    bool flag = true;
/// check if the email exist
    foreach(var user in ShopUsers){
        if (user.Email == Email){
            flag = false;
        }
    }
/// find the id
    int Id = ShopUsers.Count();
 if (flag == true){
    Id = Id+1;
    bool IsLoggedIn = false;
    ShopUser newShopUser = new ShopUser(Id, Name,ProfilePicture, PhoneNumber, Email, Address, Zipcode, Password, IsBuyer, IsLoggedIn);
    ShopUsers.Add(newShopUser);
 }
return flag;

}


/// Get all user method
public async Task<List<ShopUser>> GetAsync(){
    return ShopUsers;
}

/// get one user by id method
public async Task<List<ShopUser>> GetAsync( int Id){

    List<ShopUser> List1 = new List<ShopUser>();
    List1.Add(ShopUsers.Find(x => x.Id == Id));
    return List1;
}
/// Update a user info by id method
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



/// Detele a user by id method
public async Task<bool> DeleteAsync(int Id){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
        ShopUsers.RemoveAt(index);
        result=true;
    }

    return result;

}

/// Add Item to shopping bag method
public async Task<bool> AddItemAsync (int Id , int itemId){
    bool result = false;
    int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
    int itemindex = Merchant_API.services.ShopItemService.ShopItems.FindIndex(x=> x.Id == itemId);
    if (userindex != -1 && itemindex != -1){
//        UpdatedShopUser.Id = Id;
        ShopUsers[userindex].ShoppingBag.Add(Merchant_API.services.ShopItemService.ShopItems[itemindex]);
        result=true;
    }

    return result;

}


/// remove Item from shopping bag by id method
public async Task<bool> RemoveItemAsync(int Id , int itemId){
    bool result = false;
    int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
    int itemindex = Merchant_API.services.ShopItemService.ShopItems.FindIndex(x=> x.Id == itemId);
    if (userindex != -1 && itemindex != -1){

        int itemindex2 = ShopUsers[userindex].ShoppingBag.FindIndex(x=> x.Id == itemId);

     if (itemindex2 != -1){
        ShopUsers[userindex].ShoppingBag.RemoveAt(itemindex2);
        result=true;
        }
    }


    return result;

}


/// remove All Item from shopping bag method
public async Task<bool> RemoveAllItemAsync (int Id){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
//        UpdatedShopUser.Id = Id;
        ShopUsers[index].ShoppingBag.Clear();
        result=true;
        }

    return result;

}

/// login to the site method
public async Task<bool> LoginAsync (int Id , string Email, string Password){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
        if( ShopUsers[index].IsLoggedIn == false && ShopUsers[index].Email == Email && ShopUsers[index].Password == Password ){
        ShopUsers[index].IsLoggedIn = true;
        result=true;}
        }
    return result;

}

/// logout from the site method
public async Task<bool> LogoutAsync (int Id){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
        ShopUsers[index].IsLoggedIn = false;
        result=true;} 
    return result;

}


/// printing invoice method
public async Task<List<ShopItem>> InvoiceAsync (int Id){
    int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
    List<ShopItem> Invoiceitems = new List<ShopItem>();
    if (userindex != -1){
//        UpdatedShopUser.Id = Id;
    foreach (var item in ShopUsers[userindex].ShoppingBag)
    {
        Invoiceitems.Add(item);
    }
    }
    return Invoiceitems;

}


/// CheckOut method
public async Task<int> CheckOutAsync (int Id){
    int  sum = 0;
    int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
    List<ShopItem> checkoutitems = new List<ShopItem>();
    if (userindex != -1){
//        UpdatedShopUser.Id = Id;
    foreach (var item in ShopUsers[userindex].ShoppingBag)
    {
        sum += Int32.Parse(item.Price.TrimStart( new Char[] { ' ', '$' } ));
        checkoutitems.Add(item);
    }
        var time = DateTime.Now.ToString();
        //ShopUsers[userindex].OrderHistory.Add(Tuple.Create(checkoutitems,time));
        ShopUsers[userindex].OrderHistory.Add(checkoutitems);
        ShopUsers[userindex].ShoppingBag.Clear();
    }

    return sum;

}


/// remove All item from OrderHistory method, if user need that
public async Task<bool> RemoveAllOrderHistoryAsync (int Id){
    bool result = false;

    int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
    if (userindex != -1){
//        UpdatedShopUser.Id = Id;
        ShopUsers[userindex].OrderHistory.Clear();
        result=true;
    }

    return result;

}



}
