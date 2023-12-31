using Application.Requests.Testimonial;
using Application.Responses.Testimonial;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class TestimonialMapping : Profile
{
    public TestimonialMapping()
    {
        CreateMap<GetAllTestimonialsResponse, Testimonial>().ReverseMap();
        CreateMap<GetTestimonialResponse, Testimonial>().ReverseMap();
        CreateMap<CreateTestimonialRequest, Testimonial>().ReverseMap();
        CreateMap<UpdateTestimonialRequest, Testimonial>().ReverseMap();
        CreateMap<Task<List<Testimonial>>, Task<List<GetAllTestimonialsResponse>>>().ReverseMap();
    }
}