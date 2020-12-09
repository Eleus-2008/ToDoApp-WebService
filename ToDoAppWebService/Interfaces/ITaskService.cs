using System;
using System.Collections.Generic;
using Core.Entities;
using ToDoAppWebService.DTO;

namespace ToDoAppWebService.Interfaces
{
    public interface ITaskService
    {
        System.Threading.Tasks.Task<IEnumerable<TaskDto>> GetAllUserTasks(User user);
        
        System.Threading.Tasks.Task AddUserTasks(User user, IEnumerable<TaskDto> tasksDtos);
        System.Threading.Tasks.Task UpdateUserTasks(User user, IEnumerable<TaskDto> tasksDtos);
        System.Threading.Tasks.Task DeleteUserTasks(User user, IEnumerable<Guid> tasksGuids);
    }
}