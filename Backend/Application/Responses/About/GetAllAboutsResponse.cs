﻿namespace Application.Responses.About;

public class GetAllAboutsResponse
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}