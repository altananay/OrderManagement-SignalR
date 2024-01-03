using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface IProductService : IGenericService<Product>
{
    Task<List<Product>> GetAllProductsWithCategoriesAsync();
    Task<Product> GetProductWithCategoryAsync(Guid id);
    int GetProductCount();
    int GetProductCountByCategoryNameHamburger();
    int GetProductCountByCategoryNameDrink();
    Task<decimal> GetProductPriceAverage();
    Task<string> GetProductNameByMaxPrice();
    Task<string> GetProductNameByMinPrice();
}