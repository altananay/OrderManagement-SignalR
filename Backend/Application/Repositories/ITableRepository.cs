using Domain.Entities;

namespace Application.Repositories;

public interface ITableRepository : IGenericRepository<Table>
{
    int GetTableCountForSignalR();
    Task<int> GetTableCount();
}