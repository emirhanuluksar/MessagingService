namespace Dgtalhat.ChatService.Models;

public class Notification
{
    public int NotificationId { get; set; }
    public int SenderId { get; set; }
    public User Sender { get; set; } = new();
    public ICollection<User> Receivers { get; set; } = new HashSet<User>();
    public string NotificationContent { get; set; } = string.Empty;
    public DateTime NotificationDateTime { get; set; } = DateTime.Now;
    public bool IsRead { get; set; } = false;
}