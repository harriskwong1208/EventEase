using EventEase.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private static List<User> users = new List<User> {
                    new User { Id = 1, FirstName = "Harris", LastName= "Kwong",Phone="123-123-1234"},
                    new User { Id = 2, FirstName = "Ichigo", LastName= "Kurosaki",Phone="123-soul", City="Karakura Town"},
        };
        [HttpGet]
        //Return status code
        public async Task<ActionResult<List<User>>> GetAllUsers()
     // public async Task<IActionResult> GetAllUsers()
     // Using ActionResult instead of IActionResult shows extra details on swagger like the schema and structure of the method 
        {
            //Returns a status code of 200.
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(int id)
        {
            User user = users.Find(u => u.Id == id);
            if (user == null)
            {
                //Returns status code 404
                return NotFound($"User with the id: {id} cannot be found in the database.");
            }
            return Ok(user);
        }

    }
}
