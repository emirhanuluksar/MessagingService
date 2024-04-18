using System.Reflection;
using Dgtalhat.ChatService.Models;
using Microsoft.EntityFrameworkCore;

namespace Dgtalhat.ChatService.DataService;

public class ChatDbContext : DbContext
{
    public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
    {
    }

    public DbSet<UserConnection> UserConnections { get; set; }
    public DbSet<ChatRoom> ChatRooms { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<User> Users { get; set; }

    // Add other DbSet properties for additional entities if needed

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}