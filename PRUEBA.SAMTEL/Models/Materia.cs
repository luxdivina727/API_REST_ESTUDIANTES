using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRUEBA.SAMTEL.Models
{
    public class Materia
    {
        public Int64 MateriaId { get; set; }
        public string MateriaNombre { get; set; }
        public string MateriaObservacion { get; set; }
        public Int64 MateriaNumeroHoras { get; set; }
    }
}