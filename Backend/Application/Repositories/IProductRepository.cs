using Domain.Entities;

namespace Application.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetAllProductsWithCategoriesAsync();
    Task<Product> GetProductWithCategoryAsync(Guid id);
    int GetProductCount();
    int GetProductCountByCategoryNameHamburger();
    int GetProductCountByCategoryNameDrink();
    decimal GetProductPriceAverageForSignalR();
    string GetProductNameByMaxPriceForSignalR();
    string GetProductNameByMinPriceForSignalR();
    decimal GetAverageHamburgerPriceForSignalR();
    Task<decimal> GetProductPriceAverage();
    Task<string> ProductNameByMaxPrice();
    Task<string> ProductNameByMinPrice();
    Task<decimal> GetAverageHamburgerPrice();
    Task<List<Product>> GetAllProductsWithPaginationAsync(int page, int limit);
}