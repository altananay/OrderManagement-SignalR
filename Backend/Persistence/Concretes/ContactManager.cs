using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class ContactManager(IContactRepository repository) : IContactService
{
    public async Task<Contact> AddAsync(Contact entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(Contact entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Contact>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Contact> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public void Update(Contact entity)
    {
        repository.Update(entity);
    }
}