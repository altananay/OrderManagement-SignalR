﻿namespace Application.Responses.Booking;

public class GetBookingResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int PersonCount { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public DateTime Date { get; set; }
}