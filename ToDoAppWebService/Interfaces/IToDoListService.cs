using System.Collections.Generic;
using Core.Entities;

namespace ToDoAppWebService.Interfaces
{
    public interface IToDoListService
    {
        System.Threading.Tasks.Task<IEnumerable<ToDoList>> GetAllUserToDoLists(User user);
        
        System.Threading.Tasks.Task AddUserToDoLists(User user, IEnumerable<ToDoList> lists);
        System.Threading.Tasks.Task UpdateUserToDoLists(User user, IEnumerable<ToDoList> lists);
        System.Threading.Tasks.Task DeleteUserToDoLists(User user, IEnumerable<ToDoList> lists);
    }
}