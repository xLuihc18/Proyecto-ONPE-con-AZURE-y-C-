using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoONPE.Datos
{
    public class Conexion
    {
        //Cadena de conexion
        protected string cadena = "Server=tcp:lui-onpe.database.windows.net,1433;Initial Catalog=dblui_onpe;User ID=lui;Password=Senati2026@;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";
        //Iniciar conexion
        public SqlConnection Conectar()
        {
            return new SqlConnection(cadena);
        }
    }
}