using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using ToDoAppWebService.DTO;
using ToDoAppWebService.Interfaces;
using Task = Core.Entities.Task;

namespace ToDoAppWebService.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IToDoListRepository toDoListRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _toDoListRepository = toDoListRepository;
            _mapper = mapper;
        }

        public System.Threading.Tasks.Task<IEnumerable<TaskDto>> GetAllUserTasks(User user)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task AddUserTasks(User user, IEnumerable<TaskDto> tasksDtos)
        {
            var tasks = _mapper.Map<IEnumerable<Task>>(tasksDtos).ToList();
            var addingTasks = tasks.Where(e =>
            {
                var list = _toDoListRepository.GetByIdAsync(e.ToDoListId).Result;
                if (list?.UserId == user.Id)
                {
                    return true;
                }

                return false;
            });
            
            await _taskRepository.AddRangeAsync(addingTasks);
        }

        public async System.Threading.Tasks.Task UpdateUserTasks(User user, IEnumerable<TaskDto> tasksDtos)
        {
            /*var tasks = _mapper.Map<IEnumerable<Task>>(tasksDtos).ToList();
            var updatingTasks = tasks.Where(e =>
            {
                var list = _toDoListRepository.GetByIdAsync(e.ToDoListId).Result;
                if (list == null || list.UserId == user.Id)
                {
                    return true;
                }

                return false;
            });

            var updatingTasksEntities = new List<Task>();
            foreach (var task in updatingTasks)
            {
                var currentEntity = await _taskRepository.GetByIdAsync(task.Id);
                if (currentEntity != null)
                {
                    currentEntity
                }
            }
            
            await _taskRepository.UpdateRangeAsync(updatingTasks);*/
            
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task DeleteUserTasks(User user, IEnumerable<Guid> tasksGuids)
        {
            /*var deletingLists =
                await _taskRepository.GetAsync(e => tasksGuids.Any(id => id == e.Id) && _toDoListRepository.GetByIdAsync(e.ToDoListId).Result.UserId == user.Id);
            await _taskRepository.DeleteRangeAsync(deletingLists);*/
        }
    }
}