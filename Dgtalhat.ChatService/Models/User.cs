namespace Dgtalhat.ChatService.Models;

public class User
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ProfilePicture { get; set; } = string.Empty;
    public ICollection<ChatRoom> ChatRooms { get; set; } = new HashSet<ChatRoom>();
    public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
    public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
}