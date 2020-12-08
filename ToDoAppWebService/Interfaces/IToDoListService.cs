using System;
using System.Collections.Generic;
using Core.Entities;
using ToDoAppWebService.DTO;

namespace ToDoAppWebService.Interfaces
{
    public interface IToDoListService
    {
        System.Threading.Tasks.Task<IEnumerable<ToDoListDto>> GetAllUserToDoListsAsync(User user);
        
        System.Threading.Tasks.Task AddUserToDoListsAsync(User user, IEnumerable<ToDoListDto> listsDtos);
        System.Threading.Tasks.Task UpdateUserToDoListsAsync(User user, IEnumerable<ToDoListDto> listsDtos);
        System.Threading.Tasks.Task DeleteUserToDoListsAsync(User user, IEnumerable<Guid> listsGuids);
    }
}