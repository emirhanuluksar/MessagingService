using System.Collections.Concurrent;
using Dgtalhat.ChatService.Models;

namespace Dgtalhat.ChatService.DataService;

public class SharedDb
{
    private readonly ConcurrentDictionary<string, UserConnection> _connections = new();

    public ConcurrentDictionary<string, UserConnection> Connections => _connections;
}