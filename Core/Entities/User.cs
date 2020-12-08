﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser<Guid>
    {
        public List<ToDoList> ToDoLists { get; set; }
    }
}