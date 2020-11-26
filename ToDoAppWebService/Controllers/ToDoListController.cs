using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDoAppWebService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/todolists")]
    public class ToDoListController : Controller
    {
        
    }
}