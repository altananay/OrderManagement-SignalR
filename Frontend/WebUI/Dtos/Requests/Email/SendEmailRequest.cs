namespace WebUI.Dtos.Requests.Email;

public class SendEmailRequest
{
    public string Receiver { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
}