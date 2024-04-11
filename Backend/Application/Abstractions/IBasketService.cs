using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface IBasketService : IGenericService<Basket>
{
    Task<List<Basket>> GetBasketByTableIdAsync(Guid id);

    Task<List<Basket>> GetAllBasketsWithProductAsync();
}