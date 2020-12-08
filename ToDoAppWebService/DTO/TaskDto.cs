using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace ToDoAppWebService.DTO
{
    public class TaskDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }
        [Required]
        public bool IsDone { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? TimeOfBeginning { get; set; }
        public TimeSpan? TimeOfEnd { get; set; }
        [Required]
        public int Priority { get; set; }
        public RepeatingConditions RepeatingConditions { get; set; }
        
        [Required]
        public Guid ToDoListId { get; set; } 
    }
}