using Domain.Entities;

namespace Application.Repositories;

public interface IOrderRepository : IGenericDal<Order>
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