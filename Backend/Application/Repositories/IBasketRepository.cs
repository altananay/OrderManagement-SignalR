using Domain.Entities;

namespace Application.Repositories;

public interface IBasketRepository : IGenericDal<Basket>
{
    Task<Basket> GetBasketByTableIdAsync(Guid id);
}