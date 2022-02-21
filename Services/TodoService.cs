using Merchant_API.models;

namespace Merchant_API.services;

public class TodoService{

    /// ctor
    public TodoService()
    {
        
    }


///Default Values
    private List<Todo> todos= new List<Todo> () {
        new Todo("1", "complete the service1", "discription1", false),
        new Todo("2", "complete the service2", "discription2", false),
        new Todo("3", "complete the service3", "discription3", false),
        new Todo("4", "complete the service4", "discription4", false)
    };

/// Create Method
public async Task CreateAsynce (Todo newTodo){
    todos.Add(newTodo);
}

/// Get all method
public async Task<List<Todo>> GetAsync(){
    return todos;
}

/// get one method
public async Task<Todo> GetAsync( string Id){

    return todos.Find(x => x.Id == Id);
}
/// Update method
public async Task<bool> UpdateAsync (string Id, Todo UpdatedTodo){
    bool result = false;
    int index = todos.FindIndex(x=> x.Id == Id);
    if (index != -1){
        UpdatedTodo.Id = Id;
        todos[index]= UpdatedTodo;
        result=true;
    }

    return result;

}


/// Detele method
public async Task<bool> DeleteAsync(string Id){
    bool result = false;
    int index = todos.FindIndex(x=> x.Id == Id);
    if (index != -1){
        todos.RemoveAt(index);
        result=true;
    }

    return result;

}





}