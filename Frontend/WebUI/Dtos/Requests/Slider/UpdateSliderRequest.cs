﻿namespace WebUI.Dtos.Requests.Slider;

public class UpdateSliderRequest
{
    public Guid Id { get; set; }
    public string Title1 { get; set; }
    public string Title2 { get; set; }
    public string Title3 { get; set; }
    public string Description { get; set; }
    public string Description2 { get; set; }
    public string Description3 { get; set; }
}