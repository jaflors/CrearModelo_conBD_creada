using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Colegio.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            EstudianteMateria = new HashSet<EstudianteMateria>();
        }

        public int IdEtudiante { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<EstudianteMateria> EstudianteMateria { get; set; }
    }
}
