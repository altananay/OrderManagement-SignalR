﻿namespace WebUI.Dtos.Requests.Product;

public class UpdateProductRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
    public Guid CategoryId { get; set; }
}