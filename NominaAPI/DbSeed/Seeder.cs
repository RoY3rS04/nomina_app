using NominaAPI.Data;
using SharedModels;

namespace NominaAPI.Helpers
{
    using BCrypt.Net;
    using Bogus;

    public class Seeder
    {

        private NominaContext _context;

        private List<User> _users = [
            new User {
                Name = "Roger",
                Email = "roger@gmail.com",
                IsAdmin = true,
                Password = BCrypt.HashPassword("password")
            },
            new User {
                Name = "Roma",
                Email = "roma@gmail.com",
                IsAdmin = true,
                Password = BCrypt.HashPassword("password")
            },
            new User {
                Name = "Sherly",
                Email = "sherly@gmail.com",
                IsAdmin = true,
                Password = BCrypt.HashPassword("password")
            },
        ];

        public Seeder(NominaContext context) { _context = context; }

        public void SeedDB()
        {
            foreach (var user in _users)
            {
                _context.Users.Add(user);
            }
            
            //TODO Generate fake data    
        }
    }
}
