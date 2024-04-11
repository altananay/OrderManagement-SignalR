namespace Domain.Entities;

public class Basket
{
    public Guid Id { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductCount { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Table Table { get; set; }
    public Guid TableId { get; set; }
}