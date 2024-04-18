namespace Dgtalhat.ChatService.Models;

public class UserConnection
{
    public int ID { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public string ConnectionId { get; set; } = string.Empty;
    public int ChatRoomId { get; set; }
    public ChatRoom ChatRoom { get; set; } = null!;
}