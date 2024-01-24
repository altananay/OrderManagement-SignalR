using Application.Requests.Basket;
using Application.Responses.Basket;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class BasketMapping : Profile
{
    public BasketMapping()
    {
        CreateMap<CreateBasketRequest, Basket>().ReverseMap();
        CreateMap<UpdateBasketRequest, Basket>().ReverseMap();
        CreateMap<GetAllBasketsResponse, Basket>().ReverseMap();
        CreateMap<GetBasketResponse, Basket>().ReverseMap();
        CreateMap<Task<List<GetAllBasketsResponse>>, Task<List<Basket>>>().ReverseMap();
    }
}