﻿namespace Application.Responses.Contact;

public class GetContactResponse
{
    public Guid Id { get; set; }
    public string Location { get; set; }
    public string GoogleMapSource { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string OpenDays { get; set; }
    public string OpenDaysDescription { get; set; }
    public string OpenHours { get; set; }
}