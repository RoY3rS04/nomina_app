using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.DTOs.Ingresos
{
    public class IngresosUpdateDto
    {
        public int EmpleadoId { get; set; }
        public double SalarioOrdinario { get; set; }
        public int DiasExtras { get; set; }
        public int HorasExtras { get; set; }

        public double RiesgoLaboral { get; set; }

        public bool Nocturnidad { get; set; }

        public double Viatico { get; set; }
        public double Depreciacion { get; set; }
        public double Comision { get; set; }
        public double Bonos { get; set; }
        public DateTime FechaCierre { get; set; }
    }
}
