using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBWebAPI.Interface;

namespace MongoDBWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _usersService;
        public UsersController(IUsersService usersService) { 
         _usersService = usersService;
        }

        [HttpGet(Name ="getuser")]
        public IActionResult Get()
        {
            var result=_usersService.GetAllUsers();
            return Ok(result);
        }
    }
}
