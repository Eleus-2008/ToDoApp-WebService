using System;
using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities
{
    public class ToDoList : Entity
    {
        public string Name { get; set; }
        
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public DateTime LastUpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}