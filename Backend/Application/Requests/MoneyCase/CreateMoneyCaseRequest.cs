namespace Application.Requests.MoneyCase;

public class CreateMoneyCaseRequest
{
    public Guid Id { get; set; }
    public decimal TotalAmount { get; set; }
}