namespace Application.Requests.BasketDetail;

public class CreateBasketDetailRequest
{
    public Guid BasketId { get; set; }
    public Guid ProductId { get; set; }
    public decimal TotalPrice { get; set; }
}