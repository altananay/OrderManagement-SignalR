namespace WebUI.Dtos.Requests.Slider;

public class UpdateSliderRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}