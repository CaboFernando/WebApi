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
            //users.Add(new User { Id = 1, Username = "Douglas", Password = "123", Role = "Owner" });
            //users.Add(new User { Id = 2, Username = "Andre", Password = "456", Role = "DevMaster" });
            //users.Add(new User { Id = 3, Username = "Carlos", Password = "789", Role = "DevBack" });
            return users.Where(x => x.Username.ToLower() == username && x.Password == password).FirstOrDefault();
        }
    }
}
