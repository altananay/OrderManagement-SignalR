namespace Domain.Entities;

public class Basket
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal ProductCount { get; set; }
    public Table Table { get; set; }
    List<BasketDetail> BasketDetails { get; set; }
}