﻿namespace WebUI.Dtos.Responses.Category;

public class GetCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
}