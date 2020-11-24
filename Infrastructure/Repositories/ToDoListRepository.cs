using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Core.Repositories.Base;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class ToDoListRepository : Repository<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(SqlServerContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<ToDoList>> GetToDoListsWithTasksByUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ToDoList>> GetToDoListsWithTasksByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}