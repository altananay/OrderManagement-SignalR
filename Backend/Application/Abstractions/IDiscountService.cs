using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface IDiscountService : IGenericService<Discount>
{
    Task ChangeStatusToTrue(Guid id);
    Task ChangeStatusToFalse(Guid id);
    Task<List<Discount>> GetAllByStatusTrue();
}