namespace Merchant_API.controllers;
using System;
using Microsoft.AspNetCore.Mvc;
using Merchant_API.services;
using Merchant_API.models;

/// this is our practice in the class

[ApiController]
/*[Route("api/[controller]")]*/
//[Route("/")]
[Route("test/[controller]")]
public class ShopController : ControllerBase {
    private readonly ShopService _shopService;
    public ShopController(ShopService shopService)
    {
        this._shopService=shopService;
    }

//recieve all data!
[HttpGet]
public async Task<List<Shop>> Get(){
    return await _shopService.GetAsync();
}


//recieve one data
[HttpGet("{id}")]
public async Task<ActionResult<Shop>> Get(string Id){
    var result = await _shopService.GetAsync(Id);
        if (result is null) {
        return NotFound();
        }
    return result;
}

//make new 
[HttpPost]
public async Task<ActionResult> Post(Shop newshop){
    await _shopService.CreateAsynce(newshop);
    return CreatedAtAction(nameof(Get), new {Id=newshop.Id}, newshop);

}

//update by id
[HttpPut("{id}")]
public async Task<ActionResult> Update(string Id, Shop updatedShop){

        bool updated = await _shopService.UpdateAsync(Id, updatedShop);
        if (!updated) {
            // this assumes that a failed update is always caused by the object 
            // not being found. This needs to be changed if the cause may be different
            return NotFound();
        } 

    return Ok("Status: Ok");
}



//delete by id
[HttpDelete("{id}")]
public async Task<ActionResult> Delete (string Id){

    var todo = await _shopService.GetAsync(Id);
        if (todo is null) {
            return NotFound();
        }
        await _shopService.DeleteAsync(todo.Id);
        return Ok("Status: Ok");
}




}


// //recieve data by id!
// [HttpGet("{id}")]
// public async Task<ActionResult<Todo>> Get(string Id){
//     var todo = await _mongodbService.GetAsync(Id);
//     if (todo is null) {
//         return NotFound();
//     }
//     return todo;
// }

// //update by id
// [HttpPut("json{id}")]
// public async Task<ActionResult> Update2(string Id, Shop updatedShop){
//   await _shopService.Update2Async(Id, updatedShop);
//     return Ok("Status: Ok");
// }