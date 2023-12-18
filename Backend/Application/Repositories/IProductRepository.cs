using Domain.Entities;

namespace Application.Repositories;

public interface IProductRepository : IGenericDal<Product>
{
    Task<List<Product>> GetAllProductsWithCategoriesAsync();
}