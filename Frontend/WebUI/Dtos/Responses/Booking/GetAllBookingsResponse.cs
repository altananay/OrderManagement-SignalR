namespace WebUI.Dtos.Responses.Booking;

public class GetAllBookingsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
}