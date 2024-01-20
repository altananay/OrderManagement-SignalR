using Application.Requests.Slider;
using Application.Responses.Slider;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class SliderMapping : Profile
{
    public SliderMapping()
    {
        CreateMap<CreateSliderRequest, Slider>().ReverseMap();
        CreateMap<UpdateSliderRequest, Slider>().ReverseMap();
        CreateMap<GetAllSlidersResponse, Slider>().ReverseMap();
        CreateMap<GetSliderResponse, Slider>().ReverseMap();
        CreateMap<Task<List<GetAllSlidersResponse>>, Task<List<Slider>>>().ReverseMap();
    }
}