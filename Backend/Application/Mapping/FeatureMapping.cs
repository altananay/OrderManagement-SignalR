using Application.Requests.Feature;
using Application.Responses.Feature;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class FeatureMapping : Profile
{
    public FeatureMapping()
    {
        CreateMap<GetAllFeaturesResponse, Feature>().ReverseMap();
        CreateMap<GetFeatureResponse, Feature>().ReverseMap();
        CreateMap<CreateFeatureRequest, Feature>().ReverseMap();
        CreateMap<UpdateFeatureRequest, Feature>().ReverseMap();
        CreateMap<Task<List<GetAllFeaturesResponse>>, Task<List<Feature>>>().ReverseMap();
    }
}