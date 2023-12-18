using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class ContactManager(IContactRepository repository) : IContactService
{
    public void Add(Contact entity)
    {
        repository.Add(entity);
    }

    public void Delete(Contact entity)
    {
        repository.Delete(entity);
    }

    public List<Contact> GetAll()
    {
        return repository.GetAll();
    }

    public Contact GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public void Update(Contact entity)
    {
        repository.Update(entity);
    }
}