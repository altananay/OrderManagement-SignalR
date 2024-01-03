namespace Domain.Entities;

public class OrderDetail
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Count { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}