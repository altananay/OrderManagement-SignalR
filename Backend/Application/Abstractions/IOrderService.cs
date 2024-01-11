using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface IOrderService : IGenericService<Order>
{
    int GetOrderCountForSignalR();
    int GetActiveOrderCountForSignalR();
    decimal GetLastOrderPriceForSignalR();
    decimal GetTodayTotalPriceForSignalR();
    Task<int> GetOrderCount();
    Task<int> GetActiveOrderCount();
    Task<decimal> GetLastOrderPrice();
    Task<decimal> GetTodayTotalPrice();
}