using EventEase.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Api.Services.UserService
{
    public interface IUserService
    {
       
        List<User> GetAllUsers();
        
        User GetUser(int id);

        User AddUser(User user);

        User UpdateUser(int id, User request);
       List<User> DeleteUser(int id);
    }
}
