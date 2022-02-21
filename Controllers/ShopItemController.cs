namespace Merchant_API.controllers;
using Microsoft.AspNetCore.Mvc;
using Merchant_API.services;
using Merchant_API.models;

[ApiController]
/*[Route("api/[controller]")]*/
//[Route("/")]
[Route("[controller]")]
public class ShopItemController : ControllerBase {
    private readonly ShopItemService _ShopItemService;
    public ShopItemController(ShopItemService ShopItemService)
    {
        this._ShopItemService=ShopItemService;
    }



[HttpGet]
public async Task<List<ShopItem>> Get(){
    return await _ShopItemService.GetAsync();
}



[HttpGet("{id}")]
public async Task<ActionResult<ShopItem>> Get(string Id){
    var ShopItem = await _ShopItemService.GetAsync(Id);
    if (ShopItem is null) {
        return NotFound();
    }
    return ShopItem;
}


[HttpPost]
public async Task<ActionResult> Post(ShopItem newShopItem){
    await _ShopItemService.CreateAsynce(newShopItem);
    return CreatedAtAction(nameof(Get), new {Id=newShopItem.Id},newShopItem);

}

[HttpPut("{id}")]
public async Task<ActionResult> Update(string Id, ShopItem updatedShopItem){
    var ShopItem = await _ShopItemService.GetAsync(Id);
    if (ShopItem is null) {
        return NotFound();
    }
    updatedShopItem.Id = ShopItem.Id;

    bool updated = await _ShopItemService.UpdateAsync(Id,updatedShopItem);
    if (!updated){
        // object not found is the only reaon for this return we can change it in future :>
        return NotFound();
    }
    return NoContent();
}


[HttpDelete("{id}")]
public async Task<ActionResult> Delete (string Id){
    var ShopItem = await _ShopItemService.GetAsync(Id);
    if (ShopItem is null) {
        return NotFound();
    }
    await _ShopItemService.DeleteAsync(ShopItem.Id);

    return NoContent();
}




}