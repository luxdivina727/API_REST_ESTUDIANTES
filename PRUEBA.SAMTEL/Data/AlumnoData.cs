using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PRUEBA.SAMTEL.Models;


namespace PRUEBA.SAMTEL.Data
{
    public class AlumnoData
    {
        public static List<Alumno> Listar()
        {
            List<Alumno> listadoAlumnos = new List<Alumno>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ListarAlumno", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listadoAlumnos.Add(new Alumno()
                            {
                                AlumnoId = Convert.ToInt64(dr["AlumnoId"]),
                                AlumnoNombre = Convert.ToString(dr["AlumnoNombre"]),
                                AlumnoApellido = Convert.ToString(dr["AlumnoNombre"]),
                                AlumnoDireccion = Convert.ToString(dr["AlumnoDireccion"]),
                                AlumnoTelefono = Convert.ToInt64(dr["AlumnoTelefono"]),
                                AlumnoFechaNacimiento = Convert.ToDateTime(dr["AlumnoFechaNacimiento"]),
                                TipoIdentificacionId = Convert.ToInt16(dr["TipoIdentificacionId"]),
                                AlumnoIdentificacion = Convert.ToInt64(dr["AlumnoIdentificacion"]),
                            });
                        }

                    }



                    return listadoAlumnos;
                }
                catch (Exception ex)
                {
                    return listadoAlumnos;
                }
            }
        }
        public static bool Registrar(Alumno alumno)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("InsertarAlumno", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@alumnoNombre", alumno.AlumnoNombre);
                cmd.Parameters.AddWithValue("@alumnoApellido", alumno.AlumnoApellido);
                cmd.Parameters.AddWithValue("@alumnoDireccion", alumno.AlumnoDireccion);
                cmd.Parameters.AddWithValue("@alumnoTelefono", alumno.AlumnoTelefono);
                cmd.Parameters.AddWithValue("@alumnoFechaNacimiento", alumno.AlumnoFechaNacimiento);
                cmd.Parameters.AddWithValue("@tipoIdentificacionId", alumno.TipoIdentificacionId);
                cmd.Parameters.AddWithValue("@alumnoIdentificacion", alumno.AlumnoIdentificacion);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}