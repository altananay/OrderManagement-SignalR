﻿namespace Application.Requests.Message;

public class CreateMessageRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}