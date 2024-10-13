namespace WebUI.Dtos.Requests.Basket;

public class CreateBasketRequest
{
    public int ProductCount { get; set; }
    public Guid ProductId { get; set; }
    public Guid TableId { get; set; }
}