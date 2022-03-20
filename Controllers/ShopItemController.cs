namespace Merchant_API.controllers;
using Microsoft.AspNetCore.Mvc;
using Merchant_API.services;
using Merchant_API.models;

// this is the shopItem API

[ApiController]
/*[Route("api/[controller]")]*/
[Route("/")]
[Route("[controller]")]
public class ShopItemController : ControllerBase {
    private readonly ShopItemService _ShopItemService;
    public ShopItemController(ShopItemService ShopItemService)
    {
        this._ShopItemService=ShopItemService;
    }


// get all the shop items
[HttpGet]
public async Task<List<ShopItem>> Get(){
    return await _ShopItemService.GetAsync();
}


// get the shop item by id
[HttpGet("{id}")]
public async Task<ActionResult<ShopItem>> Get(int Id){
    var ShopItem = await _ShopItemService.GetAsync(Id);
    if (ShopItem is null) {
        return NotFound();
    }
    return ShopItem;
}

// create a new shop item
[HttpPost]
public async Task<ActionResult> Post(ShopItem newShopItem){
    await _ShopItemService.CreateAsynce(newShopItem);
    return CreatedAtAction(nameof(Get), new {Id=newShopItem.Id},newShopItem);

}

// create a new shop item by keys
[HttpPost("CreatebyKeys")]
public async Task<ActionResult> Createbykeys(string Name, string ShortDescription, string Description, string Picture, string Price, string Option, string Category, string Quantity){
    var ShopUsers = await _ShopItemService.GetAsync();
    await _ShopItemService.CreatebykeysAsynce(Name, ShortDescription, Description, Picture, Price, Option, Category, Quantity);
    return Ok("Status: Ok");
}

// update a shop item by id
[HttpPut("{id}")]
public async Task<ActionResult> Update(int Id, ShopItem updatedShopItem){
    var ShopItem = await _ShopItemService.GetAsync(Id);
    //check if it is null
    if (ShopItem is null) {
        return NotFound();
    }
    updatedShopItem.Id = ShopItem.Id;

    bool updated = await _ShopItemService.UpdateAsync(Id,updatedShopItem);
    if (!updated){
        // object not found is the only reaon for this return we can change it in future :>
        return NotFound();
    }
    return Ok("Status: Ok");
}

// delete a shop item by id
[HttpDelete("{id}")]
public async Task<ActionResult> Delete (int Id){
    var ShopItem = await _ShopItemService.GetAsync(Id);
    if (ShopItem is null) {
        return NotFound();
    }
    await _ShopItemService.DeleteAsync(ShopItem.Id);

    return Ok("Status: Ok");
}

// change a category name
[HttpPost("ChangeCategory")]
public async Task<ActionResult> ChangeCategory (string oldcat, string newcat){
    var ShopItem = await _ShopItemService.ChangeCategoryAsync( oldcat, newcat);
    if (ShopItem == false) {
        return NotFound();
    }else{
        return Ok("Status: Ok");
    }

    
}

// delete a category
[HttpPost("DeleteCategory")]
public async Task<ActionResult> DeleteCategory (string cat){
    var ShopItem = await _ShopItemService.DeleteCategoryAsync(cat);
    if (ShopItem == false) {
        return NotFound();
    }else{
        return Ok("Status: Ok");
    }

    
}

// delete all uncategorized items from the shop
[HttpPost("DeleteUncategorized")]
public async Task<ActionResult> DeleteUncategorized (){
    var ShopItem = await _ShopItemService.DeleteUncategorizedAsync();
    if (ShopItem == false) {
        return NotFound();
    }else{
        return Ok("Status: Ok");
    }

    
}



}