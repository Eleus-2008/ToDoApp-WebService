using System;
using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities
{
    public class User : Entity
    {
        public Guid UserId { get; set; }
        
        public List<ToDoList> ToDoLists { get; set; }
    }
}