using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRUEBA.SAMTEL.Models
{
    public class Alumno
    {
        public Int64 AlumnoId { get; set; }
        public string AlumnoNombre { get; set; }
        public string AlumnoApellido { get; set; }
        public string AlumnoDireccion { get; set; }
        public Int64 AlumnoTelefono { get; set; }
        public DateTime AlumnoFechaNacimiento { get; set; }
        public Int16 TipoIdentificacionId{ get; set; }
        public Int64 AlumnoIdentificacion { get; set; }

    }
}