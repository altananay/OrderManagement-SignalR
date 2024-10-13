using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class TableManager(ITableRepository _repository) : ITableService
{
    public async Task<Table> AddAsync(Table entity)
    {
        entity.Status = false;
        return await _repository.AddAsync(entity);
    }

    public void Delete(Table entity)
    {
        _repository.Delete(entity);
    }

    public async Task<List<Table>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Table> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public void Update(Table entity)
    {
        _repository.Update(entity);
    }

    public async Task<int> GetTableCount()
    {
        return await _repository.GetTableCount();
    }

    public int GetTableCountForSignalR()
    {
        return _repository.GetTableCountForSignalR();
    }

    public List<Table> GetAll()
    {
        return _repository.GetAllTables();
    }

    public async Task ChangeTableStatus(Guid id, bool status)
    {
        await _repository.ChangeTableStatus(id, status);
    }
}