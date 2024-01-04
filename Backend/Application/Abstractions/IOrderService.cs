﻿using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface IOrderService : IGenericService<Order>
{
    Task<int> GetOrderCount();
    Task<int> GetActiveOrderCount();
    Task<decimal> GetLastOrderPrice();
}