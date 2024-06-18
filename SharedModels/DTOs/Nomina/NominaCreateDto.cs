using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.DTOs.Nomina
{
    public class NominaCreateDto
    {
        [Required]
        public int EmpleadoId { get; set; }

        [Required]
        public int IngresosId { get; set; }

        [Required]
        public int DeduccionesId { get; set; }

        [Required]
        public DateTime FechaRealizacion { get; set; }
    }
}
