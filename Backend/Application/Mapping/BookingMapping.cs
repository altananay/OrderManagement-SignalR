using Application.Requests.Booking;
using Application.Responses.Booking;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class BookingMapping : Profile
{
    public BookingMapping()
    {
        CreateMap<Booking, GetAllBookingsResponse>().ReverseMap();
        CreateMap<Booking, GetBookingResponse>().ReverseMap();
        CreateMap<Booking, CreateBookingRequest>().ReverseMap();
        CreateMap<Booking, UpdateBookingRequest>().ReverseMap();
        CreateMap<Task<List<GetAllBookingsResponse>>, Task<List<Booking>>>().ReverseMap();
    }
}