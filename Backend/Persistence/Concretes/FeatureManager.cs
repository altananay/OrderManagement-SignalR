using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class FeatureManager(IFeatureRepository repository) : IFeatureService
{
    public async Task<Feature> AddAsync(Feature entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(Feature entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Feature>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Feature> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public void Update(Feature entity)
    {
        repository.Update(entity);
    }
}