namespace Merchant_API.controllers;
using Microsoft.AspNetCore.Mvc;
using Merchant_API.services;
using Merchant_API.models;

/// This is the chat API
[ApiController]
/*[Route("api/[controller]")]*/
//[Route("/")]
[Route("[controller]")]
public class ChatController : ControllerBase {
    private readonly ChatService _ChatService;
    public ChatController(ChatService ChatService)
    {
        this._ChatService = ChatService;
    }

// Get all chats
[HttpGet]
public async Task<List<Chat>> Get(){
    return await _ChatService.GetAsync();
}

/// Get chat by id
[HttpGet("{id}")]
public async Task<ActionResult<Chat>> Get(int Id){
    var Chat = await _ChatService.GetAsync(Id);
    if (Chat is null) {
        return NotFound();
    }
    return Chat;
}
// Post a chat by Json 
[HttpPost("Json")]
public async Task<ActionResult> Post(Chat newChat){
    await _ChatService.CreateAsynce(newChat);
    return CreatedAtAction(nameof(Get), new {Id=newChat.Id},newChat);

}

// Post a chat by value: name and content
[HttpPost]
public async Task<ActionResult> Post(string Name, string Content){
    await _ChatService.CreatewithkeysAsynce(Name, Content);
    return Ok("Status: Ok");

}

// Delete a chat by id
[HttpDelete("{id}")]
public async Task<ActionResult> Delete (int Id){
    var ShopUser = await _ChatService.GetAsync(Id);
    if (ShopUser is null) {
        return NotFound();
    }
    await _ChatService.DeleteAsync(Id);

    return Ok("Status: Ok");
}



}