using Domain.Entities;

namespace Application.Repositories;

public interface ICategoryRepository : IGenericDal<Category>
{
    public int GetCategoryCount();
    public int GetActiveCategoryCount();
    public int GetPassiveCategoryCount();
}