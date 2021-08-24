using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Base;

namespace Core.Repositories
{
    public interface ITodolistRepository : IRepository<Todolist>
    {
        Task<IEnumerable<Todolist>> GetTodolistsWithTasksByUserAsync(User user);
        Task<IEnumerable<Todolist>> GetUpdatedTodolistsWithTasksByUserAsync(User user, DateTime lastUpdateTime);
        Task<Todolist> GetTodolistWithTasksByIdAsync(Guid id);
    }
}