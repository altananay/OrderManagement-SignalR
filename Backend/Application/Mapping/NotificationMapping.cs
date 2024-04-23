using Application.Requests.Notification;
using Application.Responses.Notification;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

internal class NotificationMapping : Profile
{
    public NotificationMapping()
    {
        CreateMap<Notification, GetAllNotificationsResponse>().ReverseMap();
        CreateMap<Notification, GetNotificationResponse>().ReverseMap();
        CreateMap<Notification, CreateNotificationRequest>().ReverseMap();
        CreateMap<Notification, UpdateNotificationRequest>().ReverseMap();
        CreateMap<Task<List<GetAllNotificationsResponse>>, Task<List<Notification>>>().ReverseMap();
    }
}