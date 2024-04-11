namespace Application.Requests.Basket;

public class CreateBasketRequest
{
    public decimal ProductPrice { get; set; }
    public int ProductCount { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid ProductId { get; set; }
    public Guid TableId { get; set; }
}