using AutoMapper;
using Core.Entities;
using ToDoAppWebService.DTO;

namespace ToDoAppWebService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Todolist, TodolistDto>().ReverseMap();
            CreateMap<TodolistItem, TaskDto>().ReverseMap();
        }
    }
}