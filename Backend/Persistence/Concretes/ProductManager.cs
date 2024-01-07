using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class ProductManager(IProductRepository repository) : IProductService
{
    public async Task<Product> AddAsync(Product entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(Product entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<List<Product>> GetAllProductsWithCategoriesAsync()
    {
        return await repository.GetAllProductsWithCategoriesAsync();
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<Product> GetProductWithCategoryAsync(Guid id)
    {
        return await repository.GetProductWithCategoryAsync(id);
    }

    public void Update(Product entity)
    {
        repository.Update(entity);
    }

    public int GetProductCount()
    {
        return repository.GetProductCount();
    }

    public int GetProductCountByCategoryNameHamburger()
    {
        return repository.GetProductCountByCategoryNameHamburger();
    }

    public int GetProductCountByCategoryNameDrink()
    {
        return repository.GetProductCountByCategoryNameDrink();
    }

    public async Task<decimal> GetProductPriceAverage()
    {
        return await repository.GetProductPriceAverage();
    }

    public async Task<string> GetProductNameByMaxPrice()
    {
        return await repository.ProductNameByMaxPrice();
    }

    public async Task<string> GetProductNameByMinPrice()
    {
        return await repository.ProductNameByMinPrice();
    }

    public async Task<decimal> GetAverageHamburgerPrice()
    {
        return await repository.GetAverageHamburgerPrice();
    }

    public decimal GetProductPriceAverageForSignalR()
    {
        return repository.GetProductPriceAverageForSignalR();
    }

    public string GetProductNameByMaxPriceForSignalR()
    {
        return repository.GetProductNameByMaxPriceForSignalR();
    }
}