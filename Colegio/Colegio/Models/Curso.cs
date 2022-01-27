using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Colegio.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Estudiante = new HashSet<Estudiante>();
        }

        public int IdCursos { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Estudiante> Estudiante { get; set; }
    }
}
