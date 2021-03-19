using System;
using System.Collections.Generic;

#nullable disable

namespace Tarea7.Data.Models
{
    public partial class Vacuna
    {
        public Vacuna()
        {
            VacunadoVacuna1s = new HashSet<Vacunado>();
            VacunadoVacuna2s = new HashSet<Vacunado>();
        }

        public int Id { get; set; }
        public string Marca { get; set; }
        public int CantidadRestante { get; set; }
        public int CantidadEntrante { get; set; }

        public virtual ICollection<Vacunado> VacunadoVacuna1s { get; set; }
        public virtual ICollection<Vacunado> VacunadoVacuna2s { get; set; }
    }
}
