using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class SocialMediaManager(ISocialMediaRepository repository) : ISocialMediaService
{
    public void Add(SocialMedia entity)
    {
        repository.Add(entity);
    }

    public void Delete(SocialMedia entity)
    {
        repository.Delete(entity);
    }

    public List<SocialMedia> GetAll()
    {
        return repository.GetAll();
    }

    public SocialMedia GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public void Update(SocialMedia entity)
    {
        repository.Update(entity);
    }
}