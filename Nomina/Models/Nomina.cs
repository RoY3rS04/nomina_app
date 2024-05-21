using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanillaSalarial.Models
{
    public class Nomina
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("EmpleadoId")]
        public int EmpleadoId { get; set; }

        [ForeignKey("EmpleadoId")]
        [InverseProperty("Nominas")]
        public virtual Empleado Empleado { get; set; }
    }
}
