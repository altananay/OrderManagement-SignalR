namespace Application.Requests.SocialMedia;

public class UpdateSocialMediaRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string AccountUrl { get; set; }
    public string ImageUrl { get; set; }
}