namespace WebUI.Dtos.Requests.Discount;

public class CreateDiscountRequest
{
    public string Title { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}