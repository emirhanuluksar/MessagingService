namespace Dgtalhat.ChatService.Models;

public class ChatRoom
{
    public Guid ChatRoomId { get; set; }
    public ChatType ChatType { get; set; } = ChatType.Private;
    public string ChatRoomName { get; set; } = string.Empty;
    public int ChatCreatorId { get; set; }
    public User ChatCreator { get; set; } = new User();
    public ICollection<User> ChatUsers { get; set; } = new HashSet<User>();
    public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
}