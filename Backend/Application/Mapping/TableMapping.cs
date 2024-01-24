using Application.Requests.Table;
using Application.Responses.Table;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class TableMapping : Profile
{
    public TableMapping()
    {
        CreateMap<CreateTableRequest, Table>().ReverseMap();
        CreateMap<UpdateTableRequest, Table>().ReverseMap();
        CreateMap<GetAllTablesResponse, Table>().ReverseMap();
        CreateMap<GetTableResponse, Table>().ReverseMap();
        CreateMap<Task<List<GetAllTablesResponse>>, Task<List<Table>>>().ReverseMap();
    }
}