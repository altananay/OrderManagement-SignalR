﻿using Application.Abstractions;
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
}