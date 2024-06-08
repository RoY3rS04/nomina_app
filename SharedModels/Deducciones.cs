using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Deducciones
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("EmpleadoId")]
        public int EmpleadoId { get; set; }
        public double SalarioBruto { get; set; }
        public double Prestamos { get; set; }
        public double IR { get; set; }

        public double Anticipos { get; set; }

        public DateTime FechaCierre { get; set; }

        [ForeignKey("EmpleadoId")]
        [InverseProperty("Deducciones")]
        public virtual Empleado Empleado { get; set; }
    }
}
