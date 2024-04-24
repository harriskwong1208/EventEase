using EventEase.Api.Models;
using EventEase.Api.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
       public UserController(IUserService userService) {
            _userService = userService;
        }
        [HttpGet]
        //Return status code
        public async Task<ActionResult<List<User>>> GetAllUsers()
     // public async Task<IActionResult> GetAllUsers()
     // Using ActionResult instead of IActionResult shows extra details on swagger like the schema and structure of the method 
        {
            //Returns a status code of 200.

            return Ok(_userService.GetAllUsers());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var result = _userService.GetUser(id);
            if (result == null)
            {
                //Returns status code 404
                return NotFound($"User with the id: {id} cannot be found in the database.");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var result = _userService.AddUser(user);
            return Ok("Successfully added user.");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id ,User request)
        {
            var result = _userService.UpdateUser(id, request);
            if (result == null)
            {
                return NotFound("Not found in database.");
            }
            

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            if (result == null)
            {
                return NotFound("Not found in database.");
            }
            return Ok(result);
        }

    }
}
