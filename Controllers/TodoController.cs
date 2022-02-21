namespace Merchant_API.controllers;
using Microsoft.AspNetCore.Mvc;
using Merchant_API.services;
using Merchant_API.models;

[ApiController]
/*[Route("api/[controller]")]*/
[Route("/")]
//[Route("[controller]")]
public class TodoController : ControllerBase {
    private readonly TodoService _todoService;
    public TodoController(TodoService todoService)
    {
        this._todoService=todoService;
    }



[HttpGet]
public async Task<List<Todo>> Get(){
    return await _todoService.GetAsync();
}



[HttpGet("{id}")]
public async Task<ActionResult<Todo>> Get(string Id){
    var todo = await _todoService.GetAsync(Id);
    if (todo is null) {
        return NotFound();
    }
    return todo;
}


[HttpPost]
public async Task<ActionResult> Post(Todo newTodo){
    await _todoService.CreateAsynce(newTodo);
    return CreatedAtAction(nameof(Get), new {Id=newTodo.Id},newTodo);

}

[HttpPut("{id}")]
public async Task<ActionResult> Update(string Id, Todo updatedTodo){
    var todo = await _todoService.GetAsync(Id);
    if (todo is null) {
        return NotFound();
    }
    updatedTodo.Id = todo.Id;

    bool updated = await _todoService.UpdateAsync(Id,updatedTodo);
    if (!updated){
        // object not found is the only reaon for this return we can change it in future :>
        return NotFound();
    }
    return NoContent();
}


[HttpDelete("{id}")]
public async Task<ActionResult> Delete (string Id){
    var todo = await _todoService.GetAsync(Id);
    if (todo is null) {
        return NotFound();
    }
    await _todoService.DeleteAsync(todo.Id);

    return NoContent();
}




}