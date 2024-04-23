using Domain.Entities;

namespace Application.Repositories;

public interface IBasketRepository : IGenericRepository<Basket>
{
    Task<List<Basket>> GetBasketByTableIdAsync(Guid id);

    Task<List<Basket>> GetAllBasketsWithProductAsync();
}