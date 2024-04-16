namespace Dgtalhat.ChatService.Models;

public class UserConnection
{
    public int ID { get; set; }
    public string ConnectionId { get; set; } = string.Empty; // Add this property to store the connection ID
    public string Username { get; set; } = string.Empty;
    public string ChatRoom { get; set; } = string.Empty;
}