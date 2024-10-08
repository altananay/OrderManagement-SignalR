﻿namespace Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }

    //many-to-one
    public List<Product> Products { get; set; }
}