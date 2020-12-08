using System.Collections.Generic;
using Core.Entities;
using Core.Repositories.Base;
using Task = Core.Entities.Task;

namespace Core.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
        System.Threading.Tasks.Task<IEnumerable<Task>> GetTasksByUserAsync(User user);
        System.Threading.Tasks.Task<IEnumerable<Task>> GetTasksByToDoListAsync(ToDoList toDoList);
    }
}