using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Tarea7.Data.Models
{
    public partial class Vacunado
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Apellido { get; set; }
        [Required]
        [StringLength(10)]
        public string Telefono { get; set; }
        public string SignoZodiacal { get; set; }
        [Required]
        public int ProvinciaId { get; set; }
        [Required]
        public int? Vacuna1Id { get; set; }
        [Required]
        public DateTime? Vacuna1Fecha { get; set; }
        public int? Vacuna2Id { get; set; }
        public DateTime? Vacuna2Fecha { get; set; }
        public float? Latitud { get; set; }
        public float? Longitud { get; set; }

        public virtual Provincia Provincia { get; set; }
        public virtual Vacuna Vacuna1 { get; set; }
        public virtual Vacuna Vacuna2 { get; set; }
    }
}
