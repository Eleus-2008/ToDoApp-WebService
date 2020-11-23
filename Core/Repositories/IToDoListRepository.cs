using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Base;
using Task = System.Threading.Tasks.Task;

namespace Core.Repositories
{
    public interface IToDoListRepository : IRepository<ToDoList>
    {
        Task<IEnumerable<ToDoList>> GetToDoListsWithTasksByUserAsync(User user);
        Task<IEnumerable<ToDoList>> GetToDoListsWithTasksByIdAsync(int id);
    }
}