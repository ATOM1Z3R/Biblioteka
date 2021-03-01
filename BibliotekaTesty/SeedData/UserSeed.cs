using Biblioteka.Models;
using System.Collections.Generic;

namespace BibliotekaTesty.SeedData
{
    public static class UserSeed
    {
        public static List<User> users = new List<User>
        {
            new User{ Id = "111", FristName = "user555", LastName = "lastname000" },
            new User{ Id = "4444", FristName = "user888", LastName = "lastname333" },
        };
    }
}
