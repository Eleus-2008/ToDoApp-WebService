using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class TodolistItem : Entity
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? TimeOfBeginning { get; set; }
        public TimeSpan? TimeOfEnd { get; set; }
        public int Priority { get; set; }
        public RepeatingConditions RepeatingConditions { get; set; }
        
        public DateTime LastUpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        
        public Guid TodolistId { get; set; }
        public Todolist Todolist { get; set; }
    }
}