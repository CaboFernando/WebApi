using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "Andre", Password = "Andre123", Role = "manager" });
            users.Add(new User { Id = 2, Username = "Carlos", Password = "Carlos123", Role = "employee" });
            return users.Where(x => x.Username.ToLower() == username && x.Password == password).FirstOrDefault();
        }
    }
}
