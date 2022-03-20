using Merchant_API.models;

namespace Merchant_API.services;

public class ChatService{

    /// ctor
    public ChatService()
    {
        
    }


///Default Values
    private List<Chat> Chats = new List<Chat> () {
        new Chat(1,"user1", "I have a question!", "2022"),
        new Chat(2, "user2", "I have a question!", "2021")
    };

/// Create Method with Json
public async Task CreateAsynce (Chat newChat){
   Chats.Add(newChat);
}


/// Create Method with keys
public async Task CreatewithkeysAsynce (string Name,string Content){
    int id = Chats.Count();
    id = id+1;
    Chat newmessage = new Chat(id,Name,Content);
    Chats.Add(newmessage);
}

/// Get all method
public async Task<List<Chat>> GetAsync(){
    return Chats;
}

/// Get one method
public async Task<Chat> GetAsync( int Id){

    return Chats.Find(x => x.Id == Id);
}

/// Detele method
public async Task<bool> DeleteAsync(int Id){
    bool result = false;
    int index = Chats.FindIndex(x=> x.Id == Id);
    if (index != -1){
        Chats.RemoveAt(index);
        result=true;
    }

    return result;

}

}
