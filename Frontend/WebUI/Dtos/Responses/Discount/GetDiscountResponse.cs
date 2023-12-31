namespace WebUI.Dtos.Responses.Discount;

public class GetDiscountResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}