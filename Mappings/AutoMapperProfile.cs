using AutoMapper;
using TodoApi.Models;
using TodoApi.DTOs;

namespace TodoApi.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateTodoRequest, Todo>();
            CreateMap<UpdateTodoRequest, Todo>();
        }
    }
}

