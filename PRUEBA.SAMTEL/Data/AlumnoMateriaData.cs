using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PRUEBA.SAMTEL.Models;

namespace PRUEBA.SAMTEL.Data
{
    public class AlumnoMateriaData
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
                                AlumnoId = Convert.ToInt64(dr["AlumnoId"]) ,
                                MateriaId = Convert.ToInt64(dr["MateriaId"]),
                                AlumnoMateriaNota = Convert.ToString(dr["AlumnoMateriaNota"]),
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
                cmd.Parameters.AddWithValue("@alumnoId", alumnoMateria.AlumnoId);
                cmd.Parameters.AddWithValue("@materiaId", alumnoMateria.MateriaId);
                cmd.Parameters.AddWithValue("@alumnoMateriaNota", alumnoMateria.AlumnoMateriaNota);

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