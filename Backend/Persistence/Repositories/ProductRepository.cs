using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly SignalRContext _context;

    public ProductRepository(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProductsWithCategoriesAsync()
    {
        return await _context.Products.Include(x => x.Category).ToListAsync();
    }

    public async Task<Product> GetProductWithCategoryAsync(Guid id)
    {
        return await _context.Products.Include(x => x.Category).Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public int GetProductCount()
    {
        return _context.Products.Count();
    }

    public int GetProductCountByCategoryNameHamburger()
    {
        return _context.Products.Where(x => x.CategoryId == (_context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.Id).FirstOrDefault())).Count();
    }

    public int GetProductCountByCategoryNameDrink()
    {
        return _context.Products.Where(x => x.CategoryId == (_context.Categories.Where(y => y.Name == "Drink").Select(z => z.Id).FirstOrDefault())).Count();
    }

    public async Task<decimal> GetProductPriceAverage()
    {
        return await _context.Products.AverageAsync(p => p.Price);
    }

    public decimal GetProductPriceAverageForSignalR()
    {
        return _context.Products.Average(p => p.Price);
    }

    public async Task<string> ProductNameByMaxPrice()
    {
        return await _context.Products.Where(p => p.Price == (_context.Products.Max(p => p.Price))).Select(p => p.Name).FirstOrDefaultAsync();
    }

    public string GetProductNameByMaxPriceForSignalR()
    {
        return _context.Products.Where(p => p.Price == (_context.Products.Max(p => p.Price))).Select(p => p.Name).FirstOrDefault();
    }

    public async Task<string> ProductNameByMinPrice()
    {
        return await _context.Products.Where(p => p.Price == (_context.Products.Min(p => p.Price))).Select(p => p.Name).FirstOrDefaultAsync();
    }

    public async Task<decimal> GetAverageHamburgerPrice()
    {
        return await _context.Products.Where(p => p.CategoryId == (_context.Categories.Where(c => c.Name == "Hamburger").Select(c => c.Id).FirstOrDefault())).AverageAsync(p => p.Price);
    }
}