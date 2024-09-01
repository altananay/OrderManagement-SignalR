using Domain.Entities;

namespace Application.Repositories;

public interface IDiscountRepository : IGenericRepository<Discount>
{
    Task ChangeStatusToTrue(Guid id);
    Task ChangeStatusToFalse(Guid id);
    Task<List<Discount>> GetAllByStatusTrue();
}