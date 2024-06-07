using NominaAPI.Data;
using SharedModels;

namespace NominaAPI.Helpers
{
    using BCrypt.Net;
    using Bogus;
    using Microsoft.EntityFrameworkCore;
    using NominaAPI.DbSeed.Fakers;

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

        public async Task SeedDB()
        {
            /*foreach (var user in _users)
            {
                _context.Users.Add(user);
            }*/

            //TODO Generate fake data    
            for(int i = 0; i< 10; i++)
            {
                var empleadoFaker = new EmpleadoFaker();
                _context.Empleados.Add(empleadoFaker.Generate());
            }

            await _context.SaveChangesAsync();

            foreach(var empleado in _context.Empleados)
            {
                var ingresosFaker = new IngresosFaker(empleado.Id);
                foreach (var ingresos in ingresosFaker.Generate(5).ToList())
                {
                    _context.Ingresos.Add(ingresos);
                };
            }

            await _context.SaveChangesAsync();
        }
    }
}
