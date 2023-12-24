using Application.Requests.Category;
using Application.Responses.Category;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Task<List<GetAllCategoriesResponse>>, Task<List<Category>>>().ReverseMap();
        CreateMap<GetAllCategoriesResponse, Category>().ReverseMap();
        CreateMap<GetCategoryResponse, Category>().ReverseMap();
        CreateMap<CreateCategoryRequest, Category>().ReverseMap();
        CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
    }
}