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
public async Task<ActionResult<ShopUser>> Get(string Id){
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

[HttpPut("{id}")]
public async Task<ActionResult> Update(string Id, ShopUser updatedShopUser){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    updatedShopUser.Id = ShopUser.Id;

    bool updated = await _ShopUserService.UpdateAsync(Id,updatedShopUser);
    if (!updated){
        // object not found is the only reaon for this return we can change it in future :>
        return NotFound();
    }
    return NoContent();
}


[HttpDelete("{id}")]
public async Task<ActionResult> Delete (string Id){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    await _ShopUserService.DeleteAsync(ShopUser.Id);

    return NoContent();
}


[HttpPut("U{id}")]
public async Task<ActionResult> Update2(string Id, ShopUser updatedShopUser){
    var ShopUser = await _ShopUserService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    updatedShopUser.Id = ShopUser.Id;

    bool updated = await _ShopUserService.Update2Async(Id,updatedShopUser);
    if (!updated){
        // object not found is the only reaon for this return we can change it in future :>
        return NotFound();
    }
    return NoContent();
}





}