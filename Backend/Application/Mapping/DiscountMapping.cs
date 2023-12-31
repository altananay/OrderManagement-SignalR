using Application.Requests.Discount;
using Application.Responses.Discount;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class DiscountMapping : Profile
{
    public DiscountMapping()
    {
        CreateMap<GetAllDiscountsResponse, Discount>().ReverseMap();
        CreateMap<GetDiscountResponse, Discount>().ReverseMap();
        CreateMap<CreateDiscountRequest, Discount>().ReverseMap();
        CreateMap<UpdateDiscountRequest, Discount>().ReverseMap();
        CreateMap<Task<List<GetAllDiscountsResponse>>, Task<List<Discount>>>().ReverseMap();
    }
}