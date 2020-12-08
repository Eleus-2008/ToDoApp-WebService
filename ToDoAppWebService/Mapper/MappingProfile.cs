using AutoMapper;
using Core.Entities;
using ToDoAppWebService.DTO;

namespace ToDoAppWebService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoList, ToDoListDto>().ReverseMap();
            CreateMap<Task, TaskDto>().ReverseMap();
        }
    }
}