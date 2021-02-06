using System;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class UpdatedToDoListsWithTasksByUserSpecification : BaseSpecification<ToDoList>
    {
        public UpdatedToDoListsWithTasksByUserSpecification(User user, DateTime lastUpdateTime) : base(e =>
            e.User == user && e.LastUpdateTime > lastUpdateTime)
        {
            AddInclude(e => e.Tasks.Where(task => task.LastUpdateTime > lastUpdateTime));
        }
    }
}