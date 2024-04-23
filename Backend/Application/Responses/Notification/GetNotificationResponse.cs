namespace Application.Responses.Notification;

public class GetNotificationResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool Status { get; set; }
}