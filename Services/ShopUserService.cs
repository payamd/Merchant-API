using Merchant_API.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Merchant_API.services;

public class ShopUserService{

        private readonly IMongoCollection<ShopUser> _UserCollection;
    /// ctor
    public ShopUserService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        var settings = MongoClientSettings.FromConnectionString(mongoDBSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _UserCollection = database.GetCollection<ShopUser>(mongoDBSettings.Value.UserCollectionName);
    }


///Default Values
    private List<ShopUser> ShopUsers = new List<ShopUser> () {
        new ShopUser("1", "Merchant", "Profile Picture2","1234567","merchant@gmail.com","Ottawa","k1n0a7", "123",false, false),
        new ShopUser("2", "Client", "Profile Picture1","1234567","client@gmail.com","Ottawa","k2l8b1", "123",true, false)
        
    };

/// Create Method
public async Task CreateAsynce (ShopUser newShopUser){
   // ShopUsers.Add(newShopUser);
       newShopUser.Id = null; // will be set by Mongo
    await _UserCollection.InsertOneAsync(newShopUser);
}


/// Get user by email!
public async Task<ShopUser> GetByEmailAsync(string Email){
    return await _UserCollection.Find<ShopUser>(user => user.Email == Email).FirstOrDefaultAsync();
}


/// Create user by keys Method
public async Task<bool> CreatebykeysAsynce (string Name,string ProfilePicture, string PhoneNumber,
    string Email, string Address,string Zipcode, string Password,bool IsBuyer){
    bool flag = true;
    var result1 = await _UserCollection.Find<ShopUser>(user => user.Email == Email).FirstOrDefaultAsync();
       if (result1 != null){
            flag = false;
       }

/// Check if the email exist
    // foreach(var user in ShopUsers){
    //     if (user.Email == Email){
    //         flag = false;
    //     }
    //}
/// Find the id
    //int Id = ShopUsers.Count();

    if (flag == true){
    string Id = null;
    bool IsLoggedIn = false;
    ShopUser newShopUser = new ShopUser(Id, Name,ProfilePicture, PhoneNumber, Email, Address, Zipcode, Password, IsBuyer, IsLoggedIn);
    await _UserCollection.InsertOneAsync(newShopUser);
    //ShopUsers.Add(newShopUser);
 }
return flag;

}


/// Get all user method
public async Task<List<ShopUser>> GetAsync(){
    //return ShopUsers;
    return await _UserCollection.Find(_ => true).ToListAsync();
}

/// Get one user by id method
public async Task<ShopUser> GetAsync(string Id){
    return await _UserCollection.Find<ShopUser>(user => user.Id == Id).FirstOrDefaultAsync();

    // List<ShopUser> List1 = new List<ShopUser>();
    // List1.Add(ShopUsers.Find(x => x.Id == Id));
    // return List1;
}
/// Update a user info by id method
public async Task<bool> UpdateAsync (string Id, ShopUser UpdatedShopUser){
    // bool result = false;
    // int index = ShopUsers.FindIndex(x=> x.Id == Id);
    // if (index != -1){
    //     UpdatedShopUser.Id = Id;
    //     ShopUsers[index]= UpdatedShopUser;
    //     result=true;
    // }

    // return result;

    ReplaceOneResult r = await _UserCollection.ReplaceOneAsync(item => item.Id == Id, UpdatedShopUser);
    return r.IsModifiedCountAvailable && r.ModifiedCount == 1;

}



/// Detele a user by id method
public async Task<bool> DeleteAsync(string Id){
    // bool result = false;
    // int index = ShopUsers.FindIndex(x=> x.Id == Id);
    // if (index != -1){
    //     ShopUsers.RemoveAt(index);
    //     result=true;
    // }

    // return result;

    DeleteResult r = await _UserCollection.DeleteOneAsync(user => user.Id == Id);
    return r.DeletedCount == 1;

}

/// Add Item to shopping bag method
public async Task<bool> AddItemAsync (string Id , string itemId, ShopUser currentUser, ShopItem currentItem){
//     bool result = false;
//     int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
//     int itemindex = Merchant_API.services.ShopItemService.ShopItems.FindIndex(x=> (x.Id).ToString() == itemId);
//     if (userindex != -1 && itemindex != -1){
// //        Add item to the list
//         ShopUsers[userindex].ShoppingBag.Add(Merchant_API.services.ShopItemService.ShopItems[itemindex]);
//         result=true;
//     }

//     return result;
    var updatedUser = currentUser;

    updatedUser.ShoppingBag.Add(currentItem);
    ReplaceOneResult r = await _UserCollection.ReplaceOneAsync(item => item.Id == Id, updatedUser);
    return r.IsModifiedCountAvailable && r.ModifiedCount == 1;

}


/// Remove Item from shopping bag by id method
public async Task<bool> RemoveItemAsync(string Id , string itemId, ShopUser currentUser){
        bool result = false;
        int userindex = ShopUsers.FindIndex(x => x.Id == Id);
        int itemindex = Merchant_API.services.ShopItemService.ShopItems.FindIndex(x => (x.Id).ToString() == itemId);
        if (userindex != -1 && itemindex != -1)
        {

            int itemindex2 = ShopUsers[userindex].ShoppingBag.FindIndex(x => (x.Id).ToString() == itemId);

            if (itemindex2 != -1)
            {
                ShopUsers[userindex].ShoppingBag.RemoveAt(itemindex2);
                result = true;
            }
        }


        return result;

}


/// Remove All Item from shopping bag method
public async Task<bool> RemoveAllItemAsync (string Id, ShopUser currentUser){
//     bool result = false;
//     int index = ShopUsers.FindIndex(x=> x.Id == Id);
//     if (index != -1){
// //        Remove all item from shopping bag;
//         ShopUsers[index].ShoppingBag.Clear();
//         result=true;
//         }

//     return result;
    currentUser.ShoppingBag.Clear();
    ReplaceOneResult r = await _UserCollection.ReplaceOneAsync(item => item.Id == Id, currentUser);
    return r.IsModifiedCountAvailable && r.ModifiedCount == 1;

}

/// Login to the site method
public async Task<bool> LoginAsync (ShopUser currentUser){
//     int result = 0;
//     int index = ShopUsers.FindIndex(x=> x.Id == Id);
// // check if user is already logged in
//     if( ShopUsers[index].IsLoggedIn == true)
//     result = -1;

//     if (index != -1){
//         if( ShopUsers[index].IsLoggedIn == false && ShopUsers[index].Email.ToLower() == Email.ToLower() && ShopUsers[index].Password == Password ){
//         ShopUsers[index].IsLoggedIn = true;
//         result=1;}
//         }
//     // force logout multiple login
//     if (result == -1)
//     ShopUsers[index].IsLoggedIn = false;

//     return result;

    currentUser.IsLoggedIn = true;
    ReplaceOneResult r = await _UserCollection.ReplaceOneAsync(item => item.Id == currentUser.Id, currentUser);
    return r.IsModifiedCountAvailable && r.ModifiedCount == 1; 

}

/// Logout from the site method
public async Task<bool> LogoutAsync (ShopUser currentUser){
    // bool result = false;
    // int index = ShopUsers.FindIndex(x=> x.Id == Id);
    // if (index != -1 && ShopUsers[index].IsLoggedIn == true){
    //     ShopUsers[index].IsLoggedIn = false;
    //     result=true;} 
    // return result;
    currentUser.IsLoggedIn = false;
    ReplaceOneResult r = await _UserCollection.ReplaceOneAsync(item => item.Id == currentUser.Id, currentUser);
    return r.IsModifiedCountAvailable && r.ModifiedCount == 1;

}


/// Printing invoice method
public async Task<List<ShopItem>> InvoiceAsync (string Id,ShopUser currentUser){
//     int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
//     List<ShopItem> Invoiceitems = new List<ShopItem>();
//     if (userindex != -1){
// //        Add item to invoice;
//     foreach (var item in ShopUsers[userindex].ShoppingBag)
//     {
//         Invoiceitems.Add(item);
//     }
//     }
//     return Invoiceitems;
    //int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
    List<ShopItem> Invoiceitems = new List<ShopItem>();
    // if (userindex != -1){
//        Add item to invoice;
    foreach (var item in currentUser.ShoppingBag)
    {
        Invoiceitems.Add(item);
    }
    //}
    return Invoiceitems;

}


/// CheckOut method
public async Task<int> CheckOutAsync (string Id, ShopUser currentUser){
    int  sum = 0;
    //int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
    List<ShopItem> checkoutitems = new List<ShopItem>();
    // if (userindex != -1){
//        Add items to checkout list;
    foreach (var item in currentUser.ShoppingBag)
    {
        sum += Int32.Parse(item.Price.TrimStart( new Char[] { ' ', '$' } ));
        checkoutitems.Add(item);
    }
    var time = DateTime.Now.ToString();
    //Add item to order list and clear the bag
    currentUser.OrderHistory.Add(checkoutitems);
    currentUser.ShoppingBag.Clear();
    //}
    if(sum!=0){
        ReplaceOneResult r = await _UserCollection.ReplaceOneAsync(item => item.Id == Id, currentUser);
    }

    return sum;


//     int  sum = 0;
//     int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
//     List<ShopItem> checkoutitems = new List<ShopItem>();
//     if (userindex != -1){
// //        Add items to checkout list;
//     foreach (var item in ShopUsers[userindex].ShoppingBag)
//     {
//         sum += Int32.Parse(item.Price.TrimStart( new Char[] { ' ', '$' } ));
//         checkoutitems.Add(item);
//     }
//         var time = DateTime.Now.ToString();
//         //Add item to order list and clear the bag
//         ShopUsers[userindex].OrderHistory.Add(checkoutitems);
//         ShopUsers[userindex].ShoppingBag.Clear();
//     }

//     return sum;

}


/// Remove All item from OrderHistory method, if user need that
public async Task<bool> RemoveAllOrderHistoryAsync (string Id, ShopUser currentUser){
    currentUser.OrderHistory.Clear();
    ReplaceOneResult r = await _UserCollection.ReplaceOneAsync(item => item.Id == Id, currentUser);
    return r.IsModifiedCountAvailable && r.ModifiedCount == 1;

//     bool result = false;

//     int userindex = ShopUsers.FindIndex(x=> x.Id == Id);
//     if (userindex != -1){
// //        Clear all
//         ShopUsers[userindex].OrderHistory.Clear();
//         result=true;
//     }

//     return result;

}



}
