using Domain.Entities;

namespace Application.Repositories;

public interface ITableRepository : IGenericDal<Table>
{
    int GetTableCountForSignalR();
    Task<int> GetTableCount();
}