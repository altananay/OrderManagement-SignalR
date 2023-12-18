using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class CategoryManager(ICategoryRepository repository) : ICategoryService
{
    public void Add(Category entity)
    {
        repository.Add(entity);
    }

    public void Delete(Category entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Category>> GetAll()
    {
        return await repository.GetAll();
    }

    public Category GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public void Update(Category entity)
    {
        repository.Update(entity);
    }
}