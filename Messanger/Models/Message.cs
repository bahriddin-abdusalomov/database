namespace Messanger.Models;

public class Message
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string MyUserName { get; set; }
    public string Messages { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set;}
}
