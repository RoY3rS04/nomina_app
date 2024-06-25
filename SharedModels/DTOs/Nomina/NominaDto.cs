using SharedModels.DTOs.Deducciones;
using SharedModels.DTOs.Empleado;
using SharedModels.DTOs.Ingresos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.DTOs.Nomina
{
    public class NominaDto
    {
        public int Id { get; set; }
        public EmpleadoDto Empleado { get; set; }
        public IngresosDto Ingresos { get; set; }
        public DeduccionesDto Deducciones { get; set; }
        public DateTime FechaRealizacion { get; set; }
    }
}
