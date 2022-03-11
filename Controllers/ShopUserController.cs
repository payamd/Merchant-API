namespace Merchant_API.controllers;
using Microsoft.AspNetCore.Mvc;
using Merchant_API.services;
using Merchant_API.models;

[ApiController]
/*[Route("api/[controller]")]*/
//[Route("/")]
[Route("[controller]")]
public class ShopUserController : ControllerBase {
    private readonly ShopUserService _ShopUserService;
    public ShopUserController(ShopUserService ShopUserService)
    {
        this._ShopUserService=ShopUserService;
    }



[HttpGet]
public async Task<List<ShopUser>> Get(){
    return await _ShopUserService.GetAsync();
}



[HttpGet("{id}")]
public async Task<ActionResult<List<ShopUser>>> Get(int Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    return ShopUser;
}


[HttpPost]
public async Task<ActionResult> Post(ShopUser newShopUser){
    await _ShopUserService.CreateAsynce(newShopUser);
    return CreatedAtAction(nameof(Get), new {Id=newShopUser.Id},newShopUser);

}


[HttpPost("Createbykeys")]
public async Task<ActionResult> Createbykeys(string Name,string ProfilePicture, string PhoneNumber,
    string Email, string Address,string Zipcode, string Password,bool IsBuyer){
    var Id=-1; 
    var ShopUsers = await _ShopUserService.GetAsync();
    await _ShopUserService.CreatebykeysAsynce(Name, ProfilePicture, PhoneNumber,
    Email, Address, Zipcode, Password, IsBuyer);

    foreach (var user in ShopUsers)
    {
        if(user.Email == Email)
        Id=user.Id;
    }

    return Ok(Id);

}

[HttpPut("{id}")]
public async Task<ActionResult> Update(int Id, ShopUser updatedShopUser){
    var ShopUser1 = await _ShopUserService.GetAsync(Id);
    var ShopUser=ShopUser1.First();
    if (ShopUser is null) {
        return NotFound();
    }
    updatedShopUser.Id = ShopUser.Id;

    bool updated = await _ShopUserService.UpdateAsync(Id,updatedShopUser);
    if (!updated){
        // object not found is the only reaon for this return we can change it in future :>
        return NotFound();
    }
    return Ok("Status: Ok");
}


[HttpDelete("{id}")]
public async Task<ActionResult> Delete (int Id){
    var ShopUser1 = await _ShopUserService.GetAsync(Id);
    var ShopUser=ShopUser1.First();
    if (ShopUser is null) {
        return NotFound();
    }
    await _ShopUserService.DeleteAsync(ShopUser.Id);

    return Ok("Status: Ok");
}

//add item
[HttpPost("Add{id}")]
public async Task<ActionResult> AddItem(int Id, int itemId){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    bool updated = await _ShopUserService.AddItemAsync(Id,itemId);
    if (!updated){
        // this is a good place to add some new code
        return NotFound();
    }
    return Ok("Status: Ok");
}


//remove item
[HttpPost("Remove{id}")]
public async Task<ActionResult> RemoveItem(int Id, int itemId){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    bool updated = await _ShopUserService.RemoveItemAsync(Id,itemId);
    if (!updated){
        // this is a good place to add some new code
        return NotFound();
    }
    return Ok("Status: Ok");
}


//remove All item
[HttpPost("RAll{id}")]
public async Task<ActionResult> RemoveAllItem(int Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    bool updated = await _ShopUserService.RemoveAllItemAsync(Id);
    if (!updated){
        // this is a good place to add some new code
        return NotFound();
    }
    return Ok("Status: Ok");
}


//Invoice
[HttpPost("Invoice{id}")]
public async Task<ActionResult> Invoice(int Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    var updated = await _ShopUserService.InvoiceAsync(Id);
    if (updated.Count == 0){
        // this is a good place to add some new code
        return NotFound("there is no Item in your bag!");
    }
    return Ok(updated);
}


//CheckOut
[HttpPost("CheckOut{id}")]
public async Task<ActionResult> CheckOut(int Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    var updated = await _ShopUserService.CheckOutAsync(Id);
    if (updated == 0){
        // this is a good place to add some new code
        return NotFound("there is no Item in your bag!");
    }
    return Ok("Status: Ok - total price  = " + updated);
}


//remove All orderHistory
[HttpPost("RAO{id}")]
public async Task<ActionResult> RemoveAllOrderHistory(int Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    bool updated = await _ShopUserService.RemoveAllOrderHistoryAsync(Id);
    if (!updated){
        // this is a good place to add some new code
        return NotFound();
    }
    return Ok("Status: Ok");
}


//loggin 
[HttpPost("login")]
public async Task<ActionResult> Login(string Email, string Password){
    //var ShopUsers = await _ShopUserService.getAllUsersAsync();

    //foreach user in ShopUsers{}
    var Id=-1; 

    var ShopUsers = await _ShopUserService.GetAsync();
    if (ShopUsers is null) {
        return NotFound();
    } else{
        foreach (var user in ShopUsers)
        {
            if (user.Email == Email){
                Id = user.Id;
            }
            
        }
    }
    if (Id!=-1){
     bool updated = await _ShopUserService.LoginAsync(Id, Email, Password);
    if (!updated){
        // this is a good place to add some new code
        return NotFound();
    }
    return Ok(Id);

    }else{
            return NotFound();
    }

}

//loggout
[HttpPost("logout{id}")]
public async Task<ActionResult> Loginout(int Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    bool updated = await _ShopUserService.LogoutAsync(Id);
    if (!updated){
        // this is a good place to add some new code
        return NotFound();
    }
    return Ok("Status: Ok");
}




}