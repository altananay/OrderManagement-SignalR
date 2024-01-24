namespace Application.Responses.Table;

public class GetAllTablesResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}