using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class CategoryManager(ICategoryRepository repository) : ICategoryService
{
    public async Task<Category> AddAsync(Category entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(Category entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public void Update(Category entity)
    {
        repository.Update(entity);
    }

    public int GetCategoryCount()
    {
        return repository.GetCategoryCount();
    }

    public int GetActiveCategoryCount()
    {
        return repository.GetActiveCategoryCount();
    }

    public int GetPassiveCategoryCount()
    {
        return repository.GetPassiveCategoryCount();
    }
}