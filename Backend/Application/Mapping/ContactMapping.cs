using Application.Requests.Contact;
using Application.Responses.Contact;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class ContactMapping : Profile
{
    public ContactMapping()
    {
        CreateMap<GetAllContactsResponse, Contact>().ReverseMap();
        CreateMap<GetContactResponse, Contact>().ReverseMap();
        CreateMap<CreateContactRequest, Contact>().ReverseMap();
        CreateMap<UpdateContactRequest, Contact>().ReverseMap();
        CreateMap<Task<List<GetAllContactsResponse>>, Task<List<Contact>>>().ReverseMap();
    }
}