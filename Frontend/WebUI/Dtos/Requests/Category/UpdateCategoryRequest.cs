﻿namespace WebUI.Dtos.Requests.Category;

public class UpdateCategoryRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
}