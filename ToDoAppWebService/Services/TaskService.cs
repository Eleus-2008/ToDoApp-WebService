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
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITodolistRepository _todolistRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, ITodolistRepository todolistRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _todolistRepository = todolistRepository;
            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task<IEnumerable<TaskDto>> GetAllUserTasks(User user)
        {
            var tasks = (await _todolistRepository.GetTodolistsWithTasksByUserAsync(user)).SelectMany(list => list.Items);
            var tasksDtos = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return tasksDtos;
        }

        public async System.Threading.Tasks.Task AddUserTasks(User user, IEnumerable<TaskDto> tasksDtos)
        {
            var tasks = _mapper.Map<IEnumerable<TodolistItem>>(tasksDtos).ToList();
            var addingTasks = tasks.Where(e =>
            {
                var list = _todolistRepository.GetByIdAsync(e.TodolistId).Result;
                if (list?.UserId == user.Id)
                {
                    return true;
                }

                return false;
            }).ToList();
            
            foreach (var task in addingTasks)
            {
                task.LastUpdateTime = DateTime.UtcNow;
            }
            
            await _taskRepository.AddRangeAsync(addingTasks);
        }

        public async System.Threading.Tasks.Task UpdateUserTasks(User user, IEnumerable<TaskDto> tasksDtos)
        {
            var tasks = _mapper.Map<IEnumerable<TodolistItem>>(tasksDtos).ToList();
            foreach (var task in tasks)
            {
                var currentTask = await _taskRepository.GetByIdAsync(task.Id);
                if (currentTask != null && (await _todolistRepository.GetByIdAsync(currentTask.TodolistId)).UserId == user.Id)
                {
                    currentTask.Name = task.Name;
                    currentTask.IsDone = task.IsDone;
                    currentTask.Priority = task.Priority;
                    currentTask.Date = task.Date;
                    currentTask.TimeOfBeginning = task.TimeOfBeginning;
                    currentTask.TimeOfEnd = task.TimeOfEnd;
                    currentTask.RepeatingConditions = currentTask.RepeatingConditions;
                    
                    currentTask.LastUpdateTime = DateTime.UtcNow;

                    await _taskRepository.UpdateAsync(currentTask);
                }
            }
        }

        public async System.Threading.Tasks.Task DeleteUserTasks(User user, IEnumerable<Guid> tasksGuids)
        {
            foreach (var id in tasksGuids)
            {
                var currentTask = await _taskRepository.GetByIdAsync(id);
                var canDelete = (await _todolistRepository.GetByIdAsync(currentTask.TodolistId)).UserId == user.Id;
                if (canDelete)
                {
                    currentTask.IsDeleted = true;
                    await _taskRepository.UpdateAsync(currentTask);
                }
            }
        }
    }
}