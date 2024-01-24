namespace Application.Requests.BasketDetail;

public class UpdateBasketDetailRequest
{
    public Guid Id { get; set; }
    public Guid BasketId { get; set; }
    public Guid ProductId { get; set; }
    public decimal TotalPrice { get; set; }
}