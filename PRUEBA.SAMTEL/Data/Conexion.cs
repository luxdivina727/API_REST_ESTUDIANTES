using System.Configuration;

namespace PRUEBA.SAMTEL.Data
{
    public class Conexion
    {
        public static string rutaConexion()
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();
        }
    }
}