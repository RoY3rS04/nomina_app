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
            if(_context.Users.Count() == 0)
            {
                foreach (var user in _users)
                {
                    _context.Users.Add(user);
                }
            }

            var empleadoFaker = new EmpleadoFaker();
            _context.Empleados.AddRange(empleadoFaker.Generate(10));

            await _context.SaveChangesAsync();

            List<Ingresos> ingresos = new List<Ingresos>();
            List<Deducciones> deducciones = new List<Deducciones>();

            foreach(var empleado in _context.Empleados)
            {
                //TODO REFACTORING
                ingresos = Generate<IngresosFaker, Ingresos>(empleado.Id);
                deducciones = Generate<DeduccionesFaker, Deducciones>(empleado.Id);
            }

            await _context.SaveChangesAsync();

            foreach(var empleado in _context.Empleados)
            {
                for (int i = 0; i < ingresos.Count; i++)
                {
                    Generate<NominaFaker, Nomina>(empleado.Id, ingresos[i].Id, deducciones[i].Id);
                }
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

        public List<T> Generate<EntityFaker, T>
        (
            int empleadoId,
            int? ingresosId = null,
            int? deduccionesId = null
        ) where EntityFaker : class
            where T : class
        {
            //TODO

            if (typeof(IngresosFaker).IsEquivalentTo(typeof(EntityFaker)))
            {
                var faker = new IngresosFaker(empleadoId);

                var resultFaker = faker.Generate(3);

                _context.Ingresos.AddRange(resultFaker);

                return resultFaker as List<T>;
            } else if (typeof(DeduccionesFaker).IsEquivalentTo(typeof(EntityFaker)))
            {
                var faker = new DeduccionesFaker(empleadoId);

                var resultFaker = faker.Generate(3);

                _context.Deducciones.AddRange(resultFaker);

                return resultFaker as List<T>;
            } else
            {
                if (ingresosId != null && deduccionesId != null) {
                    var faker = new NominaFaker(empleadoId, (int)ingresosId, (int)deduccionesId);

                    var resultFaker = faker.Generate(3);

                    _context.Nominas.AddRange(resultFaker);

                    return resultFaker as List<T>;
                }

                return null;
            }
        }
    }
}
