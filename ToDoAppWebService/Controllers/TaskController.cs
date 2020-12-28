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
    [Route("api/tasks/[action]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<User> _userManager;

        public TaskController(ITaskService taskService, UserManager<User> userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            return Ok(await _taskService.GetAllUserTasks(currentUser));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddTasks([FromBody]IEnumerable<TaskDto> tasks)
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            await _taskService.AddUserTasks(currentUser ,tasks);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTasks([FromBody]IEnumerable<TaskDto> tasks)
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            await _taskService.UpdateUserTasks(currentUser ,tasks);
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteTasks([FromBody]IEnumerable<Guid> tasksGuids)
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            await _taskService.DeleteUserTasks(currentUser ,tasksGuids);
            return Ok();
        }
    }
}