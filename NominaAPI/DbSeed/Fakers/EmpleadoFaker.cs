using Bogus;
using SharedModels;

namespace NominaAPI.DbSeed.Fakers
{
    public class EmpleadoFaker: Faker<Empleado>
    {

        enum EstadoCivil
        {
            Solterx,
            Casadx
        }

        enum Sexo
        {
            Masculino,
            Femenino
        }

        public EmpleadoFaker() {
            // TODO Add Rules 
            RuleFor(e => e.PrimerNombre, f => f.Name.FirstName());
            RuleFor(e => e.PrimerApellido, f => f.Name.LastName());
            RuleFor(e => e.Telefono, new Randomizer().Replace("########"));
            RuleFor(e => e.Cedula, new Randomizer().Replace("###-########-####?"));
            RuleFor(e => e.Celular, new Randomizer().Replace("########"));
            RuleFor(e => e.Estado, true);
            RuleFor(e => e.EstadoCivil, f => f.PickRandom(Enum.GetNames(typeof(EstadoCivil))));
            RuleFor(e => e.Cargo, f => f.Name.JobTitle());
            RuleFor(e => e.CodigoEmpleado, new Randomizer().Replace("****-****"));
            RuleFor(e => e.Direccion, f => f.Address.FullAddress());
            RuleFor(e => e.NumeroINSS, new Randomizer().Replace("##########"));
            RuleFor(e => e.NumeroRUC, new Randomizer().Replace("##########"));
            RuleFor(e => e.FechaContratacion, f => f.Date.Recent());
            RuleFor(e => e.Nacimento, f => f.Date.Past(new Randomizer().Number(60)));
            RuleFor(e => e.Sexo, f => f.PickRandom(Enum.GetNames(typeof(Sexo))));
        }
    }
}
