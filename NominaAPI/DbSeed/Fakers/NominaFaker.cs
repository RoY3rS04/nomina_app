using Bogus;
using SharedModels;

namespace NominaAPI.DbSeed.Fakers
{
    public class NominaFaker: Faker<Nomina>
    {
        public NominaFaker(int empleadoId) { 
            RuleFor(n => n.EmpleadoId, empleadoId);
            RuleFor(n => n.FechaRealizacion, f => f.Date.Between(
                DateTime.Parse($"01/01/{DateTime.Now.Year}"),
                DateTime.Now
            ));
        }
    }
}
