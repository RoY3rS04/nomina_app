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
                //TODO REFACTORING
                var ingresosFaker = new IngresosFaker(empleado.Id);

                var resultIngresos = ingresosFaker.Generate(3);

                _context.Ingresos.AddRange(resultIngresos);

                var deduccionesFaker = new DeduccionesFaker(empleado.Id);

                var resultDeducciones = deduccionesFaker.Generate(3);

                _context.Deducciones.AddRange(resultDeducciones);

                var nominaFaker = new NominaFaker(empleado.Id);

                var result = nominaFaker.Generate(3);

                _context.Nominas.AddRange(result);
            }

            await _context.SaveChangesAsync();
        }

        public async Task ClearDB()
        {
            await _context.Ingresos.ExecuteDeleteAsync();
            await _context.Deducciones.ExecuteDeleteAsync();
            await _context.Nominas.ExecuteDeleteAsync();
            await _context.Empleados.ExecuteDeleteAsync();
        }

        public async Task Generate<Entity>() where Entity: class, new()
        {
            //TODO
        }
    }
}
