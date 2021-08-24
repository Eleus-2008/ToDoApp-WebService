using System;
using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Todolist : Entity
    {
        public string Name { get; set; }
        
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public DateTime LastUpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        
        public List<TodolistItem> Items { get; set; } = new List<TodolistItem>();
    }
}