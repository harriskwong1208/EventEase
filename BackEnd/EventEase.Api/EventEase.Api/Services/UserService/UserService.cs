using EventEase.Api.Models;

namespace EventEase.Api.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User> {
                    new User { Id = 1, FirstName = "Harris", LastName= "Kwong",Phone="123-123-1234"},
                    new User { Id = 2, FirstName = "Ichigo", LastName= "Kurosaki",Phone="123-soul", City="Karakura Town"},
                    new User { Id = 3, FirstName = "Rukia", LastName= "Kuchiki",Phone="123-soul", City="Soul Society"},
        };

        public User AddUser(User user)
        {
            users.Add(user);

            return user;
        }

        public User UpdateUser(int id, User request)
        {
            User user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Birthday = request.Birthday;
            user.Phone = request.Phone;
            user.City = request.City;
            user.Email = request.Email;
            user.Street = request.Street;

            return user;
        }

        public List<User> DeleteUser(int id)
        {
            User user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            users.Remove(user);
            return users;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUser(int id)
        {
            User user = users.Find(u => u.Id == id);
            if (user == null)
            {
                //Returns status code 404
                return null;
            }
            return user;
        }
    }
}
