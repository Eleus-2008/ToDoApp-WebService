using System.Collections.Generic;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(SqlServerContext dbContext) : base(dbContext)
        {
        }

        public System.Threading.Tasks.Task<IEnumerable<Task>> GetTasksByUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<IEnumerable<Task>> GetTasksByToDoListAsync(ToDoList toDoList)
        {
            throw new System.NotImplementedException();
        }
    }
}