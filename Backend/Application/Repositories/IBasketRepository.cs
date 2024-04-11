using Domain.Entities;

namespace Application.Repositories;

public interface IBasketRepository : IGenericDal<Basket>
{
    Task<List<Basket>> GetBasketByTableIdAsync(Guid id);

    Task<List<Basket>> GetAllBasketsWithProductAsync();
}