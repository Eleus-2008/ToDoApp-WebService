using System;
using System.Collections.Generic;
using Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public List<ToDoList> ToDoLists { get; set; }
    }
}