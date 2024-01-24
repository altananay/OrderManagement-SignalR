namespace Domain.Entities;

public class BasketDetail
{
    public Guid Id { get; set; }
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
    public Basket Basket { get; set; }
    public Guid BasketId { get; set; }
    public decimal TotalPrice { get; set; }
}