using System;
using System.Collections.Generic;

namespace ToDoAppWebService.DTO
{
    public class TodolistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public List<TaskDto> Items { get; set; }
    }
}