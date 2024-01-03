namespace Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public string TableNumber { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set;}
    public decimal TotalPrice { get; set; }
    List<OrderDetail> OrderDetails { get; set; }
}