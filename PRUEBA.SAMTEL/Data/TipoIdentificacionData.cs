using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PRUEBA.SAMTEL.Models;

namespace PRUEBA.SAMTEL.Data
{
    public class TipoIdentificacionData
    {
        public static List<TipoIdentificacion> Listar()
        {
            List<TipoIdentificacion> listadoTipoIdentificacions = new List<TipoIdentificacion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ListarTipoIdentificacion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listadoTipoIdentificacions.Add(new TipoIdentificacion()
                            {
                                TipoIdentificacionId = Convert.ToInt64(dr["TipoIdentificacionId"]),
                                TipoIdentificacionNombre = Convert.ToString(dr["TipoIdentificacionNombre"]),
                            });
                        }

                    }



                    return listadoTipoIdentificacions;
                }
                catch (Exception ex)
                {
                    return listadoTipoIdentificacions;
                }
            }
        }
    }
}