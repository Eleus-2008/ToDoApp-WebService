using System.Collections.Generic;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class TaskRepository : Repository<TodolistItem>, ITaskRepository
    {
        public TaskRepository(SqlServerContext dbContext) : base(dbContext)
        {
        }

        public System.Threading.Tasks.Task<IEnumerable<TodolistItem>> GetTasksByUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<IEnumerable<TodolistItem>> GetTasksByToDoListAsync(Todolist todolist)
        {
            throw new System.NotImplementedException();
        }
    }
}