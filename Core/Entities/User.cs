using System;
using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        
        public Guid UserId { get; set; }
        
        public List<ToDoList> ToDoLists { get; set; }
    }
}