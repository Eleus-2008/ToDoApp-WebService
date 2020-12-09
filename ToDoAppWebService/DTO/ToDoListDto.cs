﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoAppWebService.DTO
{
    public class ToDoListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}