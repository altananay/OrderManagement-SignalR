namespace WebUI.Dtos.Responses.About;

public class GetAboutResponse
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}