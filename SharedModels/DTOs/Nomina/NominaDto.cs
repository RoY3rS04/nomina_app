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
        public int EmpleadoId { get; set; }
        public int IngresosId { get; set; }
        public int DeduccionesId { get; set; }
        public DateTime FechaRealizacion { get; set; }
    }
}
