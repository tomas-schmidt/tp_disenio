using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;



namespace tp_disenio_1
{
    class Datos
    {


        static SqlConnection conexion = new SqlConnection();
        public static int tipo_admin;


        public static void abrirConexion()
        {   
         //  conexion.ConnectionString = @"Data Source=DESKTOP-NP4J7AB; Initial Catalog=TP_Diseño; Integrated Security=Yes"; // PARA PC DE JUAN
         conexion.ConnectionString = "Server=localhost\\SQLSERVER2012;Database=ProyectoEscuela;USER ID=gd;Password=gd2016"; // PARA PC DE GABRIEL
         //       conexion.ConnectionString = "Server=localhost\\SQLSERVER2012;Database=GD1C2016;USER ID=gd;Password=gd2016"; // PARA PC DE TOMAS
            
            conexion.Open();
        }
        public static void CerrarConexion()
        {
            conexion.Close();
        }


        public static string IniciarSesion(string usuario, string contraseña)
        {
            int logueado = 0;
            string mensaje = "";
            abrirConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "loguear";
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
            cmd.Parameters.Add(new SqlParameter("@contraseña", contraseña));

            SqlParameter pLogueado = new SqlParameter("@logueado", 0);
            pLogueado.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pLogueado);

            SqlParameter pMensaje = new SqlParameter("@mensaje", SqlDbType.VarChar);
            pMensaje.Direction = ParameterDirection.Output;
            pMensaje.Size = 40;
            cmd.Parameters.Add(pMensaje);

            SqlParameter pTipo_admin = new SqlParameter("@tipo_admin", 1);
            pTipo_admin.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pTipo_admin);


            cmd.ExecuteNonQuery();
            CerrarConexion();

            logueado = Int32.Parse(cmd.Parameters["@logueado"].Value.ToString());
            //tipo_admin = Int32.Parse(cmd.Parameters["@tipo_admin"].Value.ToString());

            if (logueado > 0)
            {
                mensaje = cmd.Parameters["@mensaje"].Value.ToString();
                return mensaje;
            }

            else
            {
                return mensaje;
            }

        }

    }
}
