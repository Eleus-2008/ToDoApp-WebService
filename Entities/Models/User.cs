using System;
using ToDoApp.Model.Interfaces;

namespace ToDoApp.Model
{
    public class User : IEntity
    {
        public int Id { get; set; }
        
        public Guid UserId { get; set; }
    }
}