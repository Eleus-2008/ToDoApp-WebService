using System.Collections.Generic;
using Core.Entities;
using Core.Repositories.Base;

namespace Core.Repositories
{
    public interface ITaskRepository : IRepository<TodolistItem>
    {
        System.Threading.Tasks.Task<IEnumerable<TodolistItem>> GetTasksByUserAsync(User user);
        System.Threading.Tasks.Task<IEnumerable<TodolistItem>> GetTasksByToDoListAsync(Todolist todolist);
    }
}