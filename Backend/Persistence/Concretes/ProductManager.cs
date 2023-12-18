using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class ProductManager(IProductRepository repository) : IProductService
{
    public void Add(Product entity)
    {
        repository.Add(entity);
    }

    public void Delete(Product entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Product>> GetAll()
    {
        return await repository.GetAll();
    }

    public async Task<List<Product>> GetAllProductsWithCategoriesAsync()
    {
        return await repository.GetAllProductsWithCategoriesAsync();
    }

    public Product GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public void Update(Product entity)
    {
        repository.Update(entity);
    }
}