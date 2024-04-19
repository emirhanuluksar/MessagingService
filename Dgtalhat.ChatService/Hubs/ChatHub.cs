using Dgtalhat.ChatService.DataService;
using Dgtalhat.ChatService.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Dgtalhat.ChatService.Hubs;

public class ChatHub : Hub
{
    private readonly ChatDbContext _dbContext;

    public ChatHub(ChatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task JoinRoom(UserConnection userConnection)
    {
        // Set the connection ID for the user connection
        userConnection.ConnectionId = Context.ConnectionId;

        // Add user connection to the database
        await _dbContext.UserConnections.AddAsync(userConnection);
        await _dbContext.SaveChangesAsync();

        // Send join message to the group
        await Clients.Group(userConnection.ChatRoomId.ToString())
            .SendAsync("ReceiveMessage", "Lets Program Bot", $"{userConnection.User.UserName} has Joined the Group", DateTime.Now);

        // Send list of connected users to the group
        await SendConnectedUser(userConnection.ChatRoomId.ToString());
    }


    public async Task SendMessage(string message)
    {
        // Get user connection
        var userConnection = await _dbContext.UserConnections.FirstOrDefaultAsync(u => u.ConnectionId == Context.ConnectionId);
        if (userConnection != null)
        {
            // Send message to the group
            await Clients.Group(userConnection.ChatRoomId.ToString())
                .SendAsync("ReceiveMessage", userConnection.User.UserName, message, DateTime.Now);
        }
    }


    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        // Get user connection
        var userConnection = await _dbContext.UserConnections.FirstOrDefaultAsync(u => u.ConnectionId == Context.ConnectionId);
        if (userConnection != null)
        {
            // Remove user connection from the database
            _dbContext.UserConnections.Remove(userConnection);
            await _dbContext.SaveChangesAsync();

            // Send leave message to the group
            await Clients.Group(userConnection.ChatRoomId.ToString())
                .SendAsync("ReceiveMessage", "Lets Program bot", $"{userConnection.User.UserName} has Left the Group", DateTime.Now);

            // Send updated list of connected users to the group
            await SendConnectedUser(userConnection.ChatRoomId.ToString());
        }

        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendConnectedUser(string room)
    {
        var users = _dbContext.UserConnections
            .Where(u => u.ChatRoomId.ToString() == room)
            .Select(s => s.User.UserName);
        await Clients.Group(room).SendAsync("ConnectedUser", users);
    }
}