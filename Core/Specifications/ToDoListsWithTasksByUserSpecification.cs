using System;
using System.Linq.Expressions;
using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class ToDoListsWithTasksByUserSpecification : BaseSpecification<ToDoList>
    {
        public ToDoListsWithTasksByUserSpecification(User user) : base(e => e.ToDoListUser == user)
        {
            AddInclude(e => e.Tasks);
        }
    }
}