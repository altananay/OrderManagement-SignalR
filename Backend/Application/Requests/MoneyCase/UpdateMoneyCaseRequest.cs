namespace Application.Requests.MoneyCase;

public class UpdateMoneyCaseRequest
{
    public Guid Id { get; set; }
    public decimal TotalAmount { get; set; }
}