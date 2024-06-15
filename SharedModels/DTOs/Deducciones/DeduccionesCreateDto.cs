using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.DTOs.Deducciones
{
    public class DeduccionesCreateDto
    {
        [Required]
        public int EmpleadoId { get; set; }
        [Required]
        public double SalarioBruto { get; set; }
        public double? Prestamos { get; set; }
        public double? IR { get; set; }

        public double? Anticipos { get; set; }
        [Required]
        public DateTime? FechaCierre { get; set; }
    }
}
