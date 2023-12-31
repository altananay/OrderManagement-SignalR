namespace WebUI.Dtos.Requests.Contact;

public class CreateContactRequest
{
    public string Location { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
}