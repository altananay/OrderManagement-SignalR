namespace WebUI.Dtos.Requests.Table;

public class UpdateTableRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public bool Status { get; set; }
}