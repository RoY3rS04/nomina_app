using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.DTOs.Empleado
{
    public class EmpleadoCreateDto
    {
        [Required, StringLength(30)]
        public string CodigoEmpleado { get; set; }

        [Required, StringLength(30)]
        public string Cedula { get; set; }

        [Required, StringLength(30)]
        public string NumeroRUC { get; set; }

        [Required, StringLength(30)]
        public string NumeroINSS { get; set; }

        [Required, StringLength(30)]
        public string PrimerNombre { get; set; }

        [Required, StringLength(30)]
        public string PrimerApellido { get; set; }

        [Required]
        public DateTime Nacimento { get; set; }

        [Required, StringLength(10)]
        public string Sexo { get; set; }

        [Required, StringLength(10)]
        public string EstadoCivil { get; set; }

        [Required, StringLength(100)]
        public string Direccion { get; set; }

        [Required, StringLength(30)]
        public string Telefono { get; set; }

        [Required, StringLength(30)]
        public string Celular { get; set; }

        [Required]
        public DateTime FechaContratacion { get; set; }

        [Required, StringLength(30)]
        public string Cargo { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
