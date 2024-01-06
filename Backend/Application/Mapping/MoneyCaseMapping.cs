using Application.Requests.MoneyCase;
using Application.Responses.MoneyCase;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class MoneyCaseMapping : Profile
{
    public MoneyCaseMapping()
    {
        CreateMap<CreateMoneyCaseRequest, MoneyCase>().ReverseMap();
        CreateMap<UpdateMoneyCaseRequest, MoneyCase>().ReverseMap();
        CreateMap<GetAllMoneyCasesResponse, MoneyCase>().ReverseMap();
        CreateMap<GetMoneyCaseResponse, MoneyCase>().ReverseMap();
        CreateMap<Task<List<GetAllMoneyCasesResponse>>, Task<List<MoneyCase>>>().ReverseMap();
    }
}