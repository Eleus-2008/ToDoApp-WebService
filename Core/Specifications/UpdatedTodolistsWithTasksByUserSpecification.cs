using System;
using System.Linq;
using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class UpdatedTodolistsWithTasksByUserSpecification : BaseSpecification<Todolist>
    {
        public UpdatedTodolistsWithTasksByUserSpecification(User user, DateTime lastUpdateTime) : base(e =>
            e.User == user && e.LastUpdateTime > lastUpdateTime)
        {
            AddInclude(e => e.Items.Where(task => task.LastUpdateTime > lastUpdateTime));
        }
    }
}