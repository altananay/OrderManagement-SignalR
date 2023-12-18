using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class DiscountManager(IDiscountRepository repository) : IDiscountService
{
    public void Add(Discount entity)
    {
        repository.Add(entity);
    }

    public void Delete(Discount entity)
    {
        repository.Delete(entity);
    }

    public List<Discount> GetAll()
    {
        return repository.GetAll();
    }

    public Discount GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public void Update(Discount entity)
    {
        repository.Update(entity);
    }
}