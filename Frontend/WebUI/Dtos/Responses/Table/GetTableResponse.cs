namespace WebUI.Dtos.Responses.Table;

public class GetTableResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public bool Status { get; set; }
}