using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRUEBA.SAMTEL.Models
{
    public class AlumnoMateria
    {
        public Int64 AlumnoMateriaId { get; set; }
        public Alumno Alumno{ get; set; }
        public Materia Materia{ get; set; }
    }
}