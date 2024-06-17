using Bogus;
using SharedModels;

namespace NominaAPI.DbSeed.Fakers
{
    public class DeduccionesFaker: Faker<Deducciones>
    {
        public DeduccionesFaker(int empleadoId)
        {
            RuleFor(d => d.EmpleadoId, empleadoId);
            RuleFor(d => d.Prestamos, f => f.Random.Double(0, 10000));
            RuleFor(d => d.Anticipos, f => f.Random.Double(0, 20000));
            RuleFor(d => d.FechaCierre, f => f.Date.Between(
                DateTime.Parse($"01/01/{DateTime.Now.Year}"),
                DateTime.Now
            ));
        }
    }
}
