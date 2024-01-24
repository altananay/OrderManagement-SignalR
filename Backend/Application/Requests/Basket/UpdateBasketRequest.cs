namespace Application.Requests.Basket;

public class UpdateBasketRequest
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal ProductCount { get; set; }
    public Guid TableId { get; set; }
}