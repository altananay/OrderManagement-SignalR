using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class SocialMediaManager(ISocialMediaRepository repository) : ISocialMediaService
{
    public async Task<SocialMedia> AddAsync(SocialMedia entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(SocialMedia entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<SocialMedia>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<SocialMedia> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public void Update(SocialMedia entity)
    {
        repository.Update(entity);
    }
}