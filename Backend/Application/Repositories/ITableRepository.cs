using Domain.Entities;

namespace Application.Repositories;

public interface ITableRepository : IGenericDal<Table>
{
    Task<int> GetTableCount();
}