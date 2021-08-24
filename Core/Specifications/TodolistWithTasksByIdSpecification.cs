using System;
using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class TodolistWithTasksByIdSpecification : BaseSpecification<Todolist>
    {
        public TodolistWithTasksByIdSpecification(Guid id) : base(list => list.Id == id)
        {
            AddInclude(list => list.Items);
        }
    }
}