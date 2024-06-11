using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Nomina
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("EmpleadoId")]
        public int EmpleadoId { get; set; }

        [Column("IngresosId")]
        public int IngresosId { get; set; }

        [Column("DeduccionesId")]
        public int DeduccionesId { get; set; }

        public DateTime FechaRealizacion { get; set; }

        [ForeignKey("EmpleadoId")]
        [InverseProperty("Nominas")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("IngresosId")]
        [InverseProperty("Nomina")]
        public virtual Ingresos Ingresos { get; set; }

        [ForeignKey("DeduccionesId")]
        [InverseProperty("Nomina")]
        public virtual Deducciones Deducciones { get; set; }
    }
}
