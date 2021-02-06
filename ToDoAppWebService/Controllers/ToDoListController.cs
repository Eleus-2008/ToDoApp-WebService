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
    public class ToDoListController : Controller
    {
        private readonly IToDoListService _toDoListService;
        private readonly UserManager<User> _userManager;

        public ToDoListController(IToDoListService toDoListService, UserManager<User> userManager)
        {
            _toDoListService = toDoListService ?? throw new ArgumentNullException(nameof(toDoListService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListDto>>> GetToDoLists()
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            return Ok(await _toDoListService.GetAllUserToDoListsAsync(currentUser));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListDto>>> GetUpdatedToDoLists([FromBody]string lastUpdateTime)
        {
            var date = DateTime.Parse(lastUpdateTime);
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            return Ok(await _toDoListService.GetUpdatedUserToDoListsAsync(currentUser, date));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddToDoLists([FromBody]IEnumerable<ToDoListDto> lists)
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            await _toDoListService.AddUserToDoListsAsync(currentUser ,lists);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateToDoLists([FromBody]IEnumerable<ToDoListDto> lists)
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            await _toDoListService.UpdateUserToDoListsAsync(currentUser ,lists);
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteToDoLists([FromBody]IEnumerable<Guid> listsGuids)
        {
            var currentUser = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            await _toDoListService.DeleteUserToDoListsAsync(currentUser ,listsGuids);
            return Ok();
        }
    }
}