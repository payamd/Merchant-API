namespace Merchant_API.controllers;
using System;
using Microsoft.AspNetCore.Mvc;
using Merchant_API.services;
using Merchant_API.models;

/// this is our practice in the class

[ApiController]
/*[Route("api/[controller]")]*/
//[Route("/")]
[Route("[controller]")]
public class ShopController : ControllerBase {
    private readonly MongoDBService _mongodbService;
    public ShopController(MongoDBService mongodbService)
    {
        this._mongodbService=mongodbService;
    }

//recieve all data!
[HttpGet]
public async Task<List<Shop>> Get(){
    return await _mongodbService.GetAsync();
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

//make new todo
[HttpPost]
public async Task<ActionResult> Post([FromBody] Shop shop){
    await _mongodbService.CreateAsynce(shop);
    return CreatedAtAction(nameof(Get), new {Id=shop.Id}, shop);

}

//update by id
[HttpPut("{id}")]
public async Task<ActionResult> Update(string Id, [FromBody] string movieId){
  await _mongodbService.UpdateAsync(Id, movieId);
    return NoContent();
}

//delete by id
[HttpDelete("{id}")]
public async Task<ActionResult> Delete (string Id){
    // var todo = await _mongodbService.GetAsync(Id);
    // if (todo is null) {
    //     return NotFound();
    // }
    await _mongodbService.DeleteAsync(Id);
    return NoContent();
}




}