using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRUEBA.SAMTEL.Models
{
    public class AlumnoMateria
    {
        public Int64 AlumnoMateriaId { get; set; }
        public Int64 AlumnoId{ get; set; }
        public Int64 MateriaId{ get; set; }
        public string AlumnoMateriaNota { get; set; }
    }
}