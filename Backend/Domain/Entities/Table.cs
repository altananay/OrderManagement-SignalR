namespace Domain.Entities;

public class Table
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }

    public virtual List<Basket> Baskets { get; set; }
}