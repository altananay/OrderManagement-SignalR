using Application.Requests.Product;
using Application.Responses.Product;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Task<List<GetAllProductsWithCategoryResponse>>, Task<List<Product>>>().ReverseMap();
        CreateMap<Task<List<GetAllProductsResponse>>, Task<List<Product>>>().ReverseMap();
        CreateMap<Product, GetAllProductsResponse>().ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();
		CreateMap<Product, GetAllProductsWithCategoryResponse>().ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();
        CreateMap<Product, CreateProductRequest>().ReverseMap();
        CreateMap<Product, UpdateProductRequest>().ReverseMap();
        CreateMap<Product, GetProductResponse>().ReverseMap();
        CreateMap<Product, GetProductResponse>().ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name));
    }
}