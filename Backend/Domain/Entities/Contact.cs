﻿namespace Domain.Entities;

public class Contact
{
    public Guid Id { get; set; }
    public string Location { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
}