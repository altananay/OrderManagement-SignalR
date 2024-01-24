using Application.Requests.BasketDetail;
using Application.Responses.Basket;
using Application.Responses.BasketDetail;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class BasketDetailMapping : Profile
{
    public BasketDetailMapping()
    {
        CreateMap<CreateBasketDetailRequest, BasketDetail>().ReverseMap();
        CreateMap<UpdateBasketDetailRequest, BasketDetail>().ReverseMap();
        CreateMap<GetAllBasketDetailsResponse, BasketDetail>().ReverseMap();
        CreateMap<GetBasketDetailResponse, BasketDetail>().ReverseMap();
        CreateMap<Task<List<GetAllBasketDetailsResponse>>,Task<List<BasketDetail>>>().ReverseMap(); 
    }
}