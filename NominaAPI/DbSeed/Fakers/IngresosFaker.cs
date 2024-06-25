using Bogus;
using SharedModels;

namespace NominaAPI.DbSeed.Fakers
{
    public class IngresosFaker: Faker<Ingresos>
    {

        public IngresosFaker(int empleadoId) {

            RuleFor(i => i.EmpleadoId, empleadoId);
            RuleFor(i => i.SalarioOrdinario, f => Convert.ToDouble(f.Finance.Amount(0,100000)));
            RuleFor(i => i.Bonos, f => Convert.ToDouble(f.Finance.Amount(0, 20000)));
            RuleFor(i => i.Comision, f => Convert.ToDouble(f.Finance.Amount(0, 5000)));
            RuleFor(i => i.RiesgoLaboral, new Randomizer().Bool());
            RuleFor(i => i.Depreciacion, f => Convert.ToDouble(f.Finance.Amount(0, 2000)));
            RuleFor(i => i.DiasExtras, new Randomizer().Number(0, 30));
            RuleFor(i => i.HorasExtras, new Randomizer().Number(0, 100));
            RuleFor(i => i.Viatico, f => Convert.ToDouble(f.Finance.Amount(0, 2000)));
            RuleFor(i => i.Nocturnidad, new Randomizer().Bool());
            RuleFor(i => i.FechaCierre, f => f.Date.Between(
                DateTime.Parse($"01/01/{DateTime.Now.Year}"),
                DateTime.Now
            ));
        }
    }
}
