using System;
using System.Collections.Generic;
using Core.Entities;
using ToDoAppWebService.DTO;

namespace ToDoAppWebService.Interfaces
{
    public interface ITodolistService
    {
        System.Threading.Tasks.Task<IEnumerable<TodolistDto>> GetAllUserTodolistsAsync(User user);

        System.Threading.Tasks.Task<IEnumerable<TodolistDto>> GetUpdatedUserTodolistsAsync(User user,
            DateTime lastUpdateTime);

        System.Threading.Tasks.Task AddUserTodolistsAsync(User user, IEnumerable<TodolistDto> listsDtos);
        System.Threading.Tasks.Task UpdateUserTodolistsAsync(User user, IEnumerable<TodolistDto> listsDtos);
        System.Threading.Tasks.Task DeleteUserTodolistsAsync(User user, IEnumerable<Guid> listsGuids);
    }
}