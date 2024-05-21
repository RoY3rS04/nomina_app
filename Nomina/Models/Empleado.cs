using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanillaSalarial.Models
{
    public class Empleado
    {
        public int CodigoEmpleado { get; set; }
        public string Cedula { get; set; }
        public string RUC { get; set; }
        public string INSS { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public DateTime Nacimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public string Celular {  get; set; }
        public DateTime FechaContratacion { get; set; }

        public DateTime FechaTerminacion { get; set; }
        public string Cargo { get; set; }
        public double SalarioOrdinario { get; set; }
        public string Estado { get; set; }

        [InverseProperty("Empleado")]
        public virtual ICollection<Ingresos> Ingresos { get; set; } = new List<Ingresos>();
        [InverseProperty("Empleado")]
        public virtual ICollection<Deducciones> Deducciones { get; set; } = new List<Deducciones>();
        [InverseProperty("Empleado")]
        public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();
        
    }
}
