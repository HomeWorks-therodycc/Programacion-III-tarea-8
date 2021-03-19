using System;
using System.Collections.Generic;

#nullable disable

namespace Tarea7.Data.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Vacunados = new HashSet<Vacunado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Vacunado> Vacunados { get; set; }
    }
}
