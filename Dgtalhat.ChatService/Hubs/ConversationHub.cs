using Microsoft.AspNetCore.SignalR;

namespace Dgtalhat.ChatService.Hubs;

public class ConversationHub : Hub<IConversationHub>
{
    public async Task SendMessage(string userName, string message, Guid receiverId)
    {
        await Clients.All.SendMessage(userName, message, receiverId);
    }
}