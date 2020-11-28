using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities
{
    public class ToDoList : Entity
    {
        public string Name { get; set; }
        
        public User ToDoListUser { get; set; }
        
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}