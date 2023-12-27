namespace WebUI.Dtos.Requests.About;

public class UpdateAboutRequest
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}