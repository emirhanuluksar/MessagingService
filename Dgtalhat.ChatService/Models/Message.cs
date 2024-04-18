namespace Dgtalhat.ChatService.Models;

public class Message
{
    public int MessageId { get; set; }
    public int SenderId { get; set; }
    public User Sender { get; set; } = new();
    public ICollection<User> Receivers { get; set; } = new HashSet<User>();
    public string MessageContent { get; set; } = string.Empty;
    public DateTime MessageDateTime { get; set; } = DateTime.Now;
    public ChatRoom ChatRoom { get; set; } = new();
}