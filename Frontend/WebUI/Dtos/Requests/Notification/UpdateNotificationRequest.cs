namespace WebUI.Dtos.Requests.Notification;

public class UpdateNotificationRequest
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public string UIClass { get; set; }
}