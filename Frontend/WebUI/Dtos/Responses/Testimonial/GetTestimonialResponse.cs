namespace WebUI.Dtos.Responses.Testimonial;

public class GetTestimonialResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}