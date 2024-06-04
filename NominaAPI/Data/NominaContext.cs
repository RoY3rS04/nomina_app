using Microsoft.EntityFrameworkCore;
using SharedModels;
using System.Collections.Generic;

namespace NominaAPI.Data
{
    public class NominaContext: DbContext
    {
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Ingresos> Ingresos { get; set; }
        public DbSet<Deducciones> Deducciones { get; set; }

        public NominaContext(DbContextOptions<NominaContext> options): base(options)
        {

        }
        
    }
}
