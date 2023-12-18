using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class AboutManager(IAboutRepository repository) : IAboutService
{
    public void Add(About entity)
    {
        repository.Add(entity);
    }

    public void Delete(About entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<About>> GetAll()
    {
        return await repository.GetAll();
    }

    public About GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public void Update(About entity)
    {
        repository.Update(entity);
    }
}