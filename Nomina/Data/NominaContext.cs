using Microsoft.EntityFrameworkCore;
using PlanillaSalarial.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanillaSalarial.Data
{
    internal class NominaContext: DbContext
    {
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Ingresos> Ingresos { get; set; }
        public DbSet<Deducciones> Deducciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

            optionsBuilder.UseSqlServer(connection);

        }
    }
}
