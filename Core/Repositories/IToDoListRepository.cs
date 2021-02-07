using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Base;

namespace Core.Repositories
{
    public interface IToDoListRepository : IRepository<ToDoList>
    {
        Task<IEnumerable<ToDoList>> GetToDoListsWithTasksByUserAsync(User user);
        Task<IEnumerable<ToDoList>> GetUpdatedToDoListsWithTasksByUserAsync(User user, DateTime lastUpdateTime);
        Task<ToDoList> GetToDoListWithTasksByIdAsync(Guid id);
    }
}