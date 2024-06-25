using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class NominaInfo
    {
        public int Id { get; set; } 

        public string PrimerNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string CodigoEmpleado { get; set; }
        public string Cedula { get; set; }
        public string NumeroRUC { get; set; }
        public string NumeroINSS { get; set; }

        public double SalarioBruto { get; set; }

        public double TotalDeducciones { get; set; }

        public double SalarioNeto { get; set; } 

        public DateTime FechaRealizacion { get; set; }
    }
}
