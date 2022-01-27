using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Colegio.Models
{
    public partial class EstudianteMateria
    {
        public int IdEstudiante { get; set; }
        public int IdMateria { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
    }
}
