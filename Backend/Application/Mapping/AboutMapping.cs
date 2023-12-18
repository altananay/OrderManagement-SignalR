using Application.Requests.About;
using Application.Responses.About;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class AboutMapping : Profile
{
    public AboutMapping() { 
        CreateMap<About, CreateAboutRequest>().ReverseMap();
        CreateMap<About, CreateAboutResponse>().ReverseMap();
        CreateMap<About, UpdateAboutRequest>().ReverseMap();
        CreateMap<About, GetAboutResponse>().ReverseMap();
        CreateMap<About, GetAllAboutsResponse>().ReverseMap();
        CreateMap<Task<List<GetAllAboutsResponse>>, Task<List<About>>>().ReverseMap();
    }
}