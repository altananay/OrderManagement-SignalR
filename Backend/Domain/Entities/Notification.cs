using Application.Enums;

namespace Domain.Entities;

public class Notification
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string UIClass { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool Status { get; set; }
}