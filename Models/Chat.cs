namespace Merchant_API.models;

public class Chat{
    public int Id { get; set; }
     public string Name { get; set; }
    public string Content { get; set; }
    public string Date { get; set; }
    //    public List<ChatText> ChatContent { get; set; }
    public Chat(){
        
    }
        public Chat (int Id,string Name,string Content)
        : this()
    {
        this.Id = Id;
        this.Name = Name;
        this.Content = Content;
        this.Date = DateTime.Now.ToString();

       // this.ChatContent = new List<ChatText>()  
    }

    public Chat (int Id,string Name,string Content, string Date)
    : this()
    {
        this.Id = Id;
        this.Name = Name;
        this.Content = Content;
        this.Date = Date;

       // this.ChatContent = new List<ChatText>()  
    }

}