using Domain.Entities;

namespace Application.Repositories;

public interface IProductRepository : IGenericDal<Product>
{
    Task<List<Product>> GetAllProductsWithCategoriesAsync();
    Task<Product> GetProductWithCategoryAsync(Guid id);
    int GetProductCount();
    int GetProductCountByCategoryNameHamburger();
    int GetProductCountByCategoryNameDrink();
    decimal GetProductPriceAverageForSignalR();
    string GetProductNameByMaxPriceForSignalR();
    Task<decimal> GetProductPriceAverage();
    Task<string> ProductNameByMaxPrice();
    Task<string> ProductNameByMinPrice();
    Task<decimal> GetAverageHamburgerPrice();
}