namespace Application.Requests.Basket;

public class CreateBasketRequest
{
    public decimal TotalPrice { get; set; }
    public decimal ProductCount { get; set; }
    public Guid TableId { get; set; }
}