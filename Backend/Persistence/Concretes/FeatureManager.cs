using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class FeatureManager(IFeatureRepository repository) : IFeatureService
{
    public void Add(Feature entity)
    {
        repository.Add(entity);
    }

    public void Delete(Feature entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Feature>> GetAll()
    {
        return await repository.GetAll();
    }

    public Feature GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public void Update(Feature entity)
    {
        repository.Update(entity);
    }
}