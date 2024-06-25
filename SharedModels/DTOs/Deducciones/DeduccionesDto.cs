using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.DTOs.Deducciones
{
    public class DeduccionesDto
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public double Prestamos { get; set; }
        public double Anticipos { get; set; }
        public DateTime FechaCierre { get; set; }
    }
}
