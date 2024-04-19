namespace Dgtalhat.ChatService.Hubs;

public interface IConversationHub
{
    Task SendMessage(string userName, string message, Guid receiverId);
}