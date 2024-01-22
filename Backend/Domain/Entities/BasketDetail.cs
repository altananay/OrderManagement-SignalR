namespace Domain.Entities;

public class BasketDetail
{
    public Guid Id { get; set; }
    public Product Product { get; set; }
    public Basket Basket { get; set; }
    public decimal TotalPrice { get; set; }
}