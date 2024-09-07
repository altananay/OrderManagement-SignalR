using Application.Requests.Message;
using Application.Responses.Message;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<Message, CreateMessageRequest>().ReverseMap();
        CreateMap<Message, UpdateMessageRequest>().ReverseMap();
        CreateMap<Message, GetMessageResponse>().ReverseMap();
        CreateMap<Message, GetAllMessagesResponse>().ReverseMap();
        CreateMap<Task<List<GetAllMessagesResponse>>, Task<List<Message>>>().ReverseMap();
    }
}