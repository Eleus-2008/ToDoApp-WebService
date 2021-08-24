using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Core.Specifications;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class TodolistRepository : Repository<Todolist>, ITodolistRepository
    {
        public TodolistRepository(SqlServerContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Todolist>> GetTodolistsWithTasksByUserAsync(User user)
        {
            var spec = new TodolistsWithTasksByUserSpecification(user);
            return await GetAsync(spec);
        }

        public async Task<IEnumerable<Todolist>> GetUpdatedTodolistsWithTasksByUserAsync(User user,
            DateTime lastUpdateTime)
        {
            var spec = new UpdatedTodolistsWithTasksByUserSpecification(user, lastUpdateTime);
            return await GetAsync(spec);
        }

        public async Task<Todolist> GetTodolistWithTasksByIdAsync(Guid id)
        {
            var spec = new TodolistWithTasksByIdSpecification(id);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}