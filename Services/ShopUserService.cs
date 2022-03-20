using Merchant_API.models;

namespace Merchant_API.services;

public class ShopUserService{

    /// ctor
    public ShopUserService()
    {
     
        
    }


///Default Values
    private List<ShopUser> ShopUsers = new List<ShopUser> () {
        new ShopUser(1, "Client", "Profile Picture1","1234567","client@gmail.com","Ottawa","k2l8b1", "123",true, false),
        new ShopUser(2, "Merchant", "Profile Picture2","1234567","merchant@gmail.com","Ottawa","k1n0a7", "123",false, false)
    };

/// Create Method
public async Task CreateAsynce (ShopUser newShopUser){
    ShopUsers.Add(newShopUser);
}
/// Create user by keys Method
public async Task<bool> CreatebykeysAsynce (string Name,string ProfilePicture, string PhoneNumber,
    string Email, string Address,string Zipcode, string Password,bool IsBuyer){
    bool flag = true;
/// Check if the email exist
    foreach(var user in ShopUsers){
        if (user.Email == Email){
            flag = false;
        }
    }
/// Find the id
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

/// Get one user by id method
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
//        Add item to the list
        ShopUsers[userindex].ShoppingBag.Add(Merchant_API.services.ShopItemService.ShopItems[itemindex]);
        result=true;
    }

    return result;

}


/// Remove Item from shopping bag by id method
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


/// Remove All Item from shopping bag method
public async Task<bool> RemoveAllItemAsync (int Id){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1){
//        Remove all item from shopping bag;
        ShopUsers[index].ShoppingBag.Clear();
        result=true;
        }

    return result;

}

/// Login to the site method
public async Task<int> LoginAsync (int Id , string Email, string Password){
    int result = 0;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
// check if user is already logged in
    if( ShopUsers[index].IsLoggedIn == true)
    result = -1;

    if (index != -1){
        if( ShopUsers[index].IsLoggedIn == false && ShopUsers[index].Email.ToLower() == Email.ToLower() && ShopUsers[index].Password == Password ){
        ShopUsers[index].IsLoggedIn = true;
        result=1;}
        }
    // force logout multiple login
    if (result == -1)
    ShopUsers[index].IsLoggedIn = false;

    return result;

}

/// Logout from the site method
public async Task<bool> LogoutAsync (int Id){
    bool result = false;
    int index = ShopUsers.FindIndex(x=> x.Id == Id);
    if (index != -1 && ShopUsers[index].IsLoggedIn == true){
        ShopUsers[index].IsLoggedIn = false;
        result=true;} 
    return result;

}


/// Printing invoice method
public async Task<List<ShopItem>> InvoiceAsync (int Id){
    int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
    List<ShopItem> Invoiceitems = new List<ShopItem>();
    if (userindex != -1){
//        Add item to invoice;
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
//        Add items to checkout list;
    foreach (var item in ShopUsers[userindex].ShoppingBag)
    {
        sum += Int32.Parse(item.Price.TrimStart( new Char[] { ' ', '$' } ));
        checkoutitems.Add(item);
    }
        var time = DateTime.Now.ToString();
        //Add item to order list and clear the bag
        ShopUsers[userindex].OrderHistory.Add(checkoutitems);
        ShopUsers[userindex].ShoppingBag.Clear();
    }

    return sum;

}


/// Remove All item from OrderHistory method, if user need that
public async Task<bool> RemoveAllOrderHistoryAsync (int Id){
    bool result = false;

    int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
    if (userindex != -1){
//        Clear all
        ShopUsers[userindex].OrderHistory.Clear();
        result=true;
    }

    return result;

}



}
