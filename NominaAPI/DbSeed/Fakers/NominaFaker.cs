using Bogus;
using SharedModels;

namespace NominaAPI.DbSeed.Fakers
{
    public class NominaFaker: Faker<Nomina>
    {
        public NominaFaker(int empleadoId, int ingresosId, int deduccionesId) { 
            RuleFor(n => n.EmpleadoId, empleadoId);
            RuleFor(n => n.FechaRealizacion, f => f.Date.Between(
                DateTime.Parse($"01/01/{DateTime.Now.Year}"),
                DateTime.Now
            ));
            RuleFor(n => n.IngresosId, ingresosId);
            RuleFor(n => n.DeduccionesId, deduccionesId);
        }
    }
}
