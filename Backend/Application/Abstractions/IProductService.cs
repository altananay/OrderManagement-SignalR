using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface IProductService : IGenericService<Product>
{
    Task<List<Product>> GetAllProductsWithCategoriesAsync();
}
