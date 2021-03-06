﻿using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class ToDoListsWithTasksByUserSpecification : BaseSpecification<ToDoList>
    {
        public ToDoListsWithTasksByUserSpecification(User user) : base(e => e.User == user && !e.IsDeleted)
        {
            AddInclude(e => e.Tasks);
        }
    }
}