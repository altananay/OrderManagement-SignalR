using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface ITableService : IGenericService<Table>
{
    int GetTableCountForSignalR();
    Task<int> GetTableCount();
}