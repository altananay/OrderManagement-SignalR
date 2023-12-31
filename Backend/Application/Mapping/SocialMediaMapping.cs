using Application.Requests.SocialMedia;
using Application.Responses.SocialMedia;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class SocialMediaMapping : Profile
{
    public SocialMediaMapping()
    {
        CreateMap<CreateSocialMediaRequest, SocialMedia>().ReverseMap();
        CreateMap<UpdateSocialMediaRequest, SocialMedia>().ReverseMap();
        CreateMap<GetAllSocialMediasResponse, SocialMedia>().ReverseMap();
        CreateMap<GetSocialMediaResponse, SocialMedia>().ReverseMap();
        CreateMap<Task<List<SocialMedia>>, Task<List<GetAllSocialMediasResponse>>>().ReverseMap();
    }
}