using Microsoft.EntityFrameworkCore;

namespace Dgtalhat.ChatService.DataService;

public class ConversationDbContext : DbContext
{
    public ConversationDbContext(DbContextOptions<ConversationDbContext> options) : base(options)
    {
    }

}