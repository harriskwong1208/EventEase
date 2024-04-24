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
                    new User { Id = 3, FirstName = "Rukia", LastName= "Kuchiki",Phone="123-soul", City="Soul Society"},
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
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = users.Find(u => u.Id == id);
            if (user == null)
            {
                //Returns status code 404
                return NotFound($"User with the id: {id} cannot be found in the database.");
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            users.Add(user);
            
            return Ok("Successfully added user.");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> AddUser(int id ,User request)
        {
            User user = users.Find(u => u.Id==id);  
            if(user == null)
            {
                return NotFound("Not found in database.");
            }
            user.FirstName = request.FirstName;
            user.LastName   = request.LastName;
            user.Birthday = request.Birthday;
            user.Phone = request.Phone;
            user.City = request.City;
            user.Email = request.Email;
            user.Street = request.Street;

            return Ok("Successfully updated user.");
        }

    }
}
