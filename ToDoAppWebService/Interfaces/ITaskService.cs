using System.Collections.Generic;
using Core.Entities;

namespace ToDoAppWebService.Interfaces
{
    public interface ITaskService
    {
        System.Threading.Tasks.Task<IEnumerable<Task>> GetAllUserTasks(User user);
        
        System.Threading.Tasks.Task AddUserTasks(User user, IEnumerable<Task> tasks);
        System.Threading.Tasks.Task UpdateUserTasks(User user, IEnumerable<Task> tasks);
        System.Threading.Tasks.Task DeleteUserTasks(User user, IEnumerable<Task> tasks);
    }
}