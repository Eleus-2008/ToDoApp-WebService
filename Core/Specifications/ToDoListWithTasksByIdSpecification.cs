using System;
using System.Linq.Expressions;
using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class ToDoListWithTasksByIdSpecification : BaseSpecification<ToDoList>
    {
        public ToDoListWithTasksByIdSpecification(Guid id) : base(list => list.Id == id)
        {
            AddInclude(list => list.Tasks);
        }
    }
}