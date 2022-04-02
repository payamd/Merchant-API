namespace Merchant_API.controllers;
using Microsoft.AspNetCore.Mvc;
using Merchant_API.services;
using Merchant_API.models;

//Shop user api controller

[ApiController]
/*[Route("api/[controller]")]*/
//[Route("/")]
[Route("[controller]")]
public class ShopUserController : ControllerBase {
    private readonly ShopUserService _ShopUserService;

    private readonly ShopItemService _ShopItemService;
    public ShopUserController(ShopUserService ShopUserService, ShopItemService ShopItemService)
    {
        this._ShopUserService=ShopUserService;
        this._ShopItemService=ShopItemService;
    }



// Get all shop users
[HttpGet]
public async Task<List<ShopUser>> Get(){
    return await _ShopUserService.GetAsync();
}


// Get shop user by id
[HttpGet("{id}")]
public async Task<ActionResult<ShopUser>> Get(string Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    return ShopUser;
}


// Create a new shop user
[HttpPost]
public async Task<ActionResult> Post(ShopUser newShopUser){
    await _ShopUserService.CreateAsynce(newShopUser);
    return CreatedAtAction(nameof(Get), new {Id=newShopUser.Id},newShopUser);

}

// Create a new shop user by values
[HttpPost("Createbykeys")]
public async Task<ActionResult> Createbykeys(string Name,string ProfilePicture, string PhoneNumber,
    string Email, string Address,string Zipcode, string Password,bool IsBuyer){
    string Id="-1"; 
    var ShopUsers = await _ShopUserService.GetAsync();
    var result = await _ShopUserService.CreatebykeysAsynce(Name, ProfilePicture, PhoneNumber,
    Email, Address, Zipcode, Password, IsBuyer);

    foreach (var user in ShopUsers)
    {
        if(user.Email == Email)
        Id=user.Id;
    }
 if (result==true){    
     return Ok(Id);
     }
 else{
         return NotFound("User already exist in Database!");
 }

}

// Update a shop user by id
[HttpPut("{id}")]
public async Task<ActionResult> Update(string Id, ShopUser updatedShopUser){
    var ShopUser1 = await _ShopUserService.GetAsync(Id);
   // var ShopUser=ShopUser1.First();
      var ShopUser=ShopUser1;

    if (ShopUser is null) {
        return NotFound();
    }
    updatedShopUser.Id = ShopUser.Id;

    bool updated = await _ShopUserService.UpdateAsync(Id,updatedShopUser);
    if (!updated){
        // Object not found is the only reaon for this return we can change it in future :>
        return NotFound();
    }
    return Ok("Status: Ok");
}

// Delete a shop user by id
[HttpDelete("{id}")]
public async Task<ActionResult> Delete (string Id){
    var ShopUser1 = await _ShopUserService.GetAsync(Id);
    //var ShopUser=ShopUser1.First();
    var ShopUser=ShopUser1;

    if (ShopUser is null) {
        return NotFound();
    }
    await _ShopUserService.DeleteAsync(ShopUser.Id);

    return Ok("Status: Ok");
}

//Add item to shopping bag
[HttpPost("Add{id}")]
public async Task<ActionResult> AddItem(string Id, string itemId){
    // var ShopUser = await _ShopUserService.GetAsync(Id);
    // if (ShopUser is null) {
    //     return NotFound();
    // }
    // bool updated = await _ShopUserService.AddItemAsync(Id,itemId);
    // if (!updated){
    //     // This is a good place to add some new code
    //     return NotFound();
    // }
    // return Ok("Status: Ok");
    var ShopUser = await _ShopUserService.GetAsync(Id);          
    var ShopItem = await _ShopItemService.GetAsync(itemId);
    if (ShopUser is null || ShopItem is null) {
        return NotFound();
    }
    bool updated = await _ShopUserService.AddItemAsync(Id,itemId, ShopUser, ShopItem);
    if (!updated){
        // This is a good place to add some new code
        return NotFound();
    }
    return Ok("Status: Ok");
}


//Remove item from shopping bag
[HttpPost("Remove{id}")]
public async Task<ActionResult> RemoveItem(string Id, string itemId){
    // var ShopUser = await _ShopUserService.GetAsync(Id);
    // if (ShopUser is null) {
    //     return NotFound();
    // }
    // bool updated = await _ShopUserService.RemoveItemAsync(Id,itemId);
    // if (!updated){
    //     // if not found
    //     return NotFound();
    // }
    // return Ok("Status: Ok");
    var ShopUser = await _ShopUserService.GetAsync(Id);
    var ShopItem = await _ShopItemService.GetAsync(itemId);
    if (ShopUser is null || ShopItem is null) {
        return NotFound();
    }
    bool updated = await _ShopUserService.RemoveItemAsync(Id,itemId, ShopUser);
    if (!updated){
        // if not found
        return NotFound();
    }
    return Ok("Status: Ok");
}


//Remove All items from a user shopping bag
[HttpPost("RAll{id}")]
public async Task<ActionResult> RemoveAllItem(string Id){
    // var ShopUser = await _ShopUserService.GetAsync(Id);
    // if (ShopUser is null) {
    //     return NotFound();
    // }
    // bool updated = await _ShopUserService.RemoveAllItemAsync(Id);
    // if (!updated){
    //     // If not found
    //     return NotFound();
    // }
    // return Ok("Status: Ok");
     var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    bool updated = await _ShopUserService.RemoveAllItemAsync(Id,ShopUser);
    if (!updated){
        // If not found
        return NotFound();
    }
    return Ok("Status: Ok");
}


//Printing Invoice
[HttpPost("Invoice{id}")]
public async Task<ActionResult> Invoice(string Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    var updated = await _ShopUserService.InvoiceAsync(Id,ShopUser);
    if (updated.Count == 0){
        // if there is no item in the bag
        return NotFound("there is no Item in your bag!");
    }
    return Ok(updated);

    // var ShopUser = await _ShopUserService.GetAsync(Id);
    // if (ShopUser is null) {
    //     return NotFound();
    // }
    // var updated = await _ShopUserService.InvoiceAsync(Id);
    // if (updated.Count == 0){
    //     // if there is no item in the bag
    //     return NotFound("there is no Item in your bag!");
    // }
    // return Ok(updated);
}


//CheckOut user by id
[HttpPost("CheckOut{id}")]
public async Task<ActionResult> CheckOut(string Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    var updated = await _ShopUserService.CheckOutAsync(Id, ShopUser);
    if (updated == 0){
        // if there is no item in the bag
        return NotFound("there is no Item in your bag!");
    }
    return Ok("Status: Ok - total price  = " + updated);
    // var ShopUser = await _ShopUserService.GetAsync(Id);
    // if (ShopUser is null) {
    //     return NotFound();
    // }
    // var updated = await _ShopUserService.CheckOutAsync(Id);
    // if (updated == 0){
    //     // if there is no item in the bag
    //     return NotFound("there is no Item in your bag!");
    // }
    // return Ok("Status: Ok - total price  = " + updated);
}


//Remove All item from order history for a user
[HttpPost("RAO{id}")]
public async Task<ActionResult> RemoveAllOrderHistory(string Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    bool updated = await _ShopUserService.RemoveAllOrderHistoryAsync(Id, ShopUser);
    if (!updated){
        // If there is nothing to remove
        return NotFound();
    }
    return Ok("Status: Ok");

    // var ShopUser = await _ShopUserService.GetAsync(Id);
    // if (ShopUser is null) {
    //     return NotFound();
    // }
    // bool updated = await _ShopUserService.RemoveAllOrderHistoryAsync(Id);
    // if (!updated){
    //     // If there is nothing to remove
    //     return NotFound();
    // }
    // return Ok("Status: Ok");
}


//Login a user to the site
[HttpPost("login")]
public async Task<ActionResult> Login(string Email, string Password){

    var ShopUser = await _ShopUserService.GetByEmailAsync(Email);
    if(ShopUser is null){
        return NotFound("There is no user in the database!");
    }
    if(ShopUser.Password != Password){
        return NotFound("Please check your password and try again");
    }
    if(ShopUser.IsLoggedIn){
        bool logout = await _ShopUserService.LogoutAsync(ShopUser);
        if (!logout){
            return NotFound();
        }
        return NotFound("For security reasons you logged out, please login again!");
    }

    bool updated = await _ShopUserService.LoginAsync(ShopUser);
    if(!updated){
        return NotFound("Login Error!");
    }
    return Ok(ShopUser.Id);

    //await _ShopUserService.GetByEmailAsync(Email);
    //string result = await _ShopUserService.LoginAsync(string Email, string Password);


    // if(result == "0"){
    //     return NotFound("There is no user in the database!");
    // }
    // if(result == "1"){
    //     return NotFound("Please check your password and try again");
    // }
    // if(result == "2"){
    //     bool logout = await _ShopUserService.LogoutAsync(string Email);
    //     if (!logout){
    //         return NotFound();
    //     }
    //     return NotFound("For security reasons you logged out, please login again!");
    // }

    // if(result == "3"){
    //     return NotFound("Login Error!");
    // }
    // return Ok(result);

    // //var ShopUsers = await _ShopUserService.getAllUsersAsync();

    // string Id="-1"; 

    // var ShopUsers = await _ShopUserService.GetAsync();
    // if (ShopUsers is null) {
    //     return NotFound("there is no user in the database!");
    // } else{
    //     foreach (var user in ShopUsers)
    //     {
    //         if (user.Email.ToLower() == Email.ToLower()){
    //             Id = user.Id;
    //         }
            
    //     }
    // }
    // if (Id!="-1"){
    //             int updated = await _ShopUserService.LoginAsync(Id, Email, Password);
    //              if (updated == 0){
    //                  // If we don't have a user in the database or the password is wrong
    //                  return NotFound("We dont have that user in the database or your password is wrong");
    //                           }else if (updated==-1){
    //                               return NotFound("For security reasons you logged out, please login again!");
    //                           }
    //                           return Ok(Id);
    //                  ;}

    //  else{return NotFound("We dont have that user!");}

}

//Log out a user from the site by id
[HttpPost("logout{id}")]
public async Task<ActionResult> Loginout(string Id){
    // var ShopUser = await _ShopUserService.GetAsync(Id);
    // if (ShopUser is null) {
    //     return NotFound();
    // }
    // bool updated = await _ShopUserService.LogoutAsync(Id);
    // if (!updated){
    //     return NotFound();
    // }
    // return Ok("Status: Ok");
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    bool updated = await _ShopUserService.LogoutAsync(ShopUser);
    if (!updated){
        return NotFound("User is not logged in");
    }
    return Ok("Status: Ok");
}




}