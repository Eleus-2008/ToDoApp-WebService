﻿using System;
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
    public class ToDoListRepository : Repository<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(SqlServerContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ToDoList>> GetToDoListsWithTasksByUserAsync(User user)
        {
            var spec = new ToDoListsWithTasksByUserSpecification(user);
            return await GetAsync(spec);
        }

        public async Task<IEnumerable<ToDoList>> GetUpdatedToDoListsWithTasksByUserAsync(User user,
            DateTime lastUpdateTime)
        {
            var spec = new UpdatedToDoListsWithTasksByUserSpecification(user, lastUpdateTime);
            return await GetAsync(spec);
        }

        public async Task<ToDoList> GetToDoListWithTasksByIdAsync(Guid id)
        {
            var spec = new ToDoListWithTasksByIdSpecification(id);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}