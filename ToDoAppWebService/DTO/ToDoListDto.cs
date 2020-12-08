using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoAppWebService.DTO
{
    public class ToDoListDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}