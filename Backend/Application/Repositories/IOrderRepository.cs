using Domain.Entities;

namespace Application.Repositories;

public interface IOrderRepository : IGenericDal<Order>
{
    Task<int> GetOrderCount();
    Task<int> GetActiveOrderCount();
    Task<decimal> GetLastOrderPrice();
}