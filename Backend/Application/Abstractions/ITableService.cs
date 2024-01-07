using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface ITableService : IGenericService<Table>
{
    Task<int> GetTableCount();
}