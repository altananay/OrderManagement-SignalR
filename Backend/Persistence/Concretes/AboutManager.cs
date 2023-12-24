using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class AboutManager(IAboutRepository repository) : IAboutService
{
    public async Task<About> AddAsync(About entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(About entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<About>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<About> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public void Update(About entity)
    {
        repository.Update(entity);
    }
}