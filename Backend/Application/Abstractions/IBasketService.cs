using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface IBasketService : IGenericService<Basket>
{
    Task<Basket> GetBasketByTableIdAsync(Guid id);
}