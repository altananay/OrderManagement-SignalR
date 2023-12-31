﻿namespace WebUI.Dtos.Requests.Testimonial;

public class UpdateTestimonialRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}