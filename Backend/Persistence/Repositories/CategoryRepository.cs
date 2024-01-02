using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly SignalRContext _context;

    public CategoryRepository(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public int GetCategoryCount()
    {
        return _context.Categories.Count();
    }

    public int GetActiveCategoryCount()
    {
        return _context.Categories.Where(c => c.Status == true).Count();
    }

    public int GetPassiveCategoryCount()
    {
        return _context.Categories.Where(x => x.Status == false).Count();
    }
}