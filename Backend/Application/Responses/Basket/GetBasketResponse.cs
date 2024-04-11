﻿namespace Application.Responses.Basket;

public class GetBasketResponse
{
    public Guid Id { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductCount { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid ProductId { get; set; }
    public Guid TableId { get; set; }
}