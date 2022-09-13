using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PRUEBA.SAMTEL.Models;

namespace PRUEBA.SAMTEL.Data
{
    public class AlumnoMateriaMateriaData
    {
        public static List<AlumnoMateria> Listar()
        {
            List<AlumnoMateria> listadoAlumnoMaterias = new List<AlumnoMateria>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ListarAlumnoMateria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listadoAlumnoMaterias.Add(new AlumnoMateria()
                            {
                                AlumnoMateriaId = Convert.ToInt64(dr["AlumnoMateriaId"]),
                                Alumno = new Alumno { AlumnoId = Convert.ToInt64(dr["AlumnoId"]) },
                                Materia = new Materia { MateriaId = Convert.ToInt64(dr["MateriaId"]) },
                            });
                        }

                    }



                    return listadoAlumnoMaterias;
                }
                catch (Exception ex)
                {
                    return listadoAlumnoMaterias;
                }
            }
        }
        public static bool Registrar(AlumnoMateria alumnoMateria)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("InsertarAlumnoMateria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@alumnoId", alumnoMateria.Alumno.AlumnoId);
                cmd.Parameters.AddWithValue("@materiaId", alumnoMateria.Materia.MateriaId);

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