﻿using Bogus;
using SharedModels;

namespace NominaAPI.DbSeed.Fakers
{
    public class EmpleadoFaker: Faker<Empleado>
    {

        private string[] EstadosCiviles = ["Soltero/a", "Casado/a"];

        enum Sexo
        {
            Masculino,
            Femenino
        }

        public EmpleadoFaker() {
            // TODO Add Rules 
            RuleFor(e => e.PrimerNombre, f => f.Name.FirstName());
            RuleFor(e => e.PrimerApellido, f => f.Name.LastName());
            RuleFor(e => e.Telefono, f => new Randomizer().Replace("########"));
            RuleFor(e => e.Cedula, f => new Randomizer().Replace("###-########-####?"));
            RuleFor(e => e.Celular, f => new Randomizer().Replace("########"));
            RuleFor(e => e.Estado, true);
            RuleFor(e => e.EstadoCivil, f => f.PickRandom(EstadosCiviles));
            RuleFor(e => e.Cargo, f => f.Name.JobTitle());
            RuleFor(e => e.CodigoEmpleado, f => new Randomizer().Replace("****-****"));
            RuleFor(e => e.Direccion, f => f.Address.FullAddress());
            RuleFor(e => e.NumeroINSS, f => new Randomizer().Replace("##########"));
            RuleFor(e => e.NumeroRUC, f => new Randomizer().Replace("##########"));
            RuleFor(e => e.FechaContratacion, f => f.Date.Recent());
            RuleFor(e => e.Nacimento, f => f.Date.Past(new Randomizer().Number(60)));
            RuleFor(e => e.Sexo, f => f.PickRandom(Enum.GetNames(typeof(Sexo))));
        }
    }
}
