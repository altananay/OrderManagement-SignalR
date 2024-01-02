using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface ICategoryService : IGenericService<Category>
{
    public int GetCategoryCount();
    public int GetActiveCategoryCount();
    public int GetPassiveCategoryCount();
}