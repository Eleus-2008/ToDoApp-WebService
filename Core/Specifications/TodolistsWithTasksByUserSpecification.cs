using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class TodolistsWithTasksByUserSpecification : BaseSpecification<Todolist>
    {
        public TodolistsWithTasksByUserSpecification(User user) : base(e => e.User == user && !e.IsDeleted)
        {
            AddInclude(e => e.Items);
        }
    }
}