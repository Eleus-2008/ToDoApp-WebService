using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Task : Entity
    {
        public string Name { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? TimeOfBeginning { get; set; }
        public TimeSpan? TimeOfEnd { get; set; }
        public int Priority { get; set; }
        public RepeatingConditions RepeatingConditions { get; set; }
        
        public ToDoList ToDoList { get; set; }
    }
}