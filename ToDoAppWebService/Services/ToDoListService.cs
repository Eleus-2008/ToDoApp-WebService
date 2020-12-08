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
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _repository;
        private readonly IMapper _mapper;

        public ToDoListService(IToDoListRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async System.Threading.Tasks.Task<IEnumerable<ToDoListDto>> GetAllUserToDoListsAsync(User user)
        {
            var lists = await _repository.GetToDoListsWithTasksByUserAsync(user);
            var listsDtos = _mapper.Map<IEnumerable<ToDoListDto>>(lists);
            return listsDtos;
        }

        public async System.Threading.Tasks.Task AddUserToDoListsAsync(User user, IEnumerable<ToDoListDto> listsDtos)
        {
            var lists = _mapper.Map<IEnumerable<ToDoList>>(listsDtos).ToList();
            foreach (var list in lists)
            {
                list.UserId = user.Id;
            }

            await _repository.AddRangeAsync(lists);
        }

        public async System.Threading.Tasks.Task UpdateUserToDoListsAsync(User user, IEnumerable<ToDoListDto> listsDtos)
        {
            var lists = _mapper.Map<IEnumerable<ToDoList>>(listsDtos).ToList();
            foreach (var list in lists)
            {
                list.UserId = user.Id;
            }

            await _repository.UpdateRangeAsync(lists);
        }

        public async System.Threading.Tasks.Task DeleteUserToDoListsAsync(User user, IEnumerable<Guid> listsGuids)
        {
            var deletingLists =
                await _repository.GetAsync(e => listsGuids.Any(id => id == e.Id) && e.UserId == user.Id);
            await _repository.DeleteRangeAsync(deletingLists);
        }
    }
}