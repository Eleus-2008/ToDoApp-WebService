using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoAppWebService.DTO;
using ToDoAppWebService.Interfaces;

namespace ToDoAppWebService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/todolists/[action]")]
    public class TodolistController : Controller
    {
        private readonly ITodolistService _todolistService;
        private readonly UserManager<User> _userManager;

        public TodolistController(ITodolistService todolistService, UserManager<User> userManager)
        {
            _todolistService = todolistService ?? throw new ArgumentNullException(nameof(todolistService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodolistDto>>> GetTodolists()
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            return Ok(await _todolistService.GetAllUserTodolistsAsync(currentUser));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodolistDto>>> GetUpdatedTodolists([FromQuery]string lastUpdateTime)
        {
            var date = DateTime.Parse(lastUpdateTime);
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            return Ok(await _todolistService.GetUpdatedUserTodolistsAsync(currentUser, date));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddTodolists([FromBody]IEnumerable<TodolistDto> lists)
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            await _todolistService.AddUserTodolistsAsync(currentUser ,lists);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTodolists([FromBody]IEnumerable<TodolistDto> lists)
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            await _todolistService.UpdateUserTodolistsAsync(currentUser ,lists);
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteTodolists([FromBody]IEnumerable<Guid> listsGuids)
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            await _todolistService.DeleteUserTodolistsAsync(currentUser ,listsGuids);
            return Ok();
        }
    }
}