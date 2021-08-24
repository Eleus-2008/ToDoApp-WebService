using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using ToDoAppWebService.DTO;
using ToDoAppWebService.Interfaces;

namespace ToDoAppWebService.Services
{
    public class TodolistService : ITodolistService
    {
        private readonly ITodolistRepository _repository;
        private readonly IMapper _mapper;

        public TodolistService(ITodolistRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async System.Threading.Tasks.Task<IEnumerable<TodolistDto>> GetAllUserTodolistsAsync(User user)
        {
            var lists = await _repository.GetTodolistsWithTasksByUserAsync(user);
            var listsDtos = _mapper.Map<IEnumerable<TodolistDto>>(lists);
            return listsDtos;
        }

        public async System.Threading.Tasks.Task<IEnumerable<TodolistDto>> GetUpdatedUserTodolistsAsync(User user,
            DateTime lastUpdateTime)
        {
            var lists = await _repository.GetUpdatedTodolistsWithTasksByUserAsync(user, lastUpdateTime);
            var listsDtos = _mapper.Map<IEnumerable<TodolistDto>>(lists);
            return listsDtos;
        }

        public async System.Threading.Tasks.Task AddUserTodolistsAsync(User user, IEnumerable<TodolistDto> listsDtos)
        {
            var lists = _mapper.Map<IEnumerable<Todolist>>(listsDtos).ToList();
            foreach (var list in lists)
            {
                list.UserId = user.Id;
                list.LastUpdateTime = DateTime.UtcNow;
                foreach (var task in list.Items)
                {
                    task.LastUpdateTime = DateTime.UtcNow;
                }
            }

            await _repository.AddRangeAsync(lists);
        }

        public async System.Threading.Tasks.Task UpdateUserTodolistsAsync(User user, IEnumerable<TodolistDto> listsDtos)
        {
            var lists = _mapper.Map<IEnumerable<Todolist>>(listsDtos).ToList();
            foreach (var list in lists)
            {
                var currentList = await _repository.GetByIdAsync(list.Id);
                if (currentList != null && currentList.UserId == user.Id)
                {
                    currentList.Name = list.Name;
                    list.LastUpdateTime = DateTime.UtcNow;
                    
                    await _repository.UpdateAsync(currentList);
                }
            }
        }

        public async System.Threading.Tasks.Task DeleteUserTodolistsAsync(User user, IEnumerable<Guid> listsGuids)
        {
            foreach (var id in listsGuids)
            {
                var currentList = await _repository.GetTodolistWithTasksByIdAsync(id);
                if (currentList.UserId == user.Id)
                {
                    currentList.IsDeleted = true;
                    foreach (var task in currentList.Items)
                    {
                        task.IsDeleted = true;
                    }
                    await _repository.UpdateAsync(currentList);
                }
            }
            
        }
    }
}