using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace tp_disenio_1
{
    public class BaseDeDatos
    {
        public String parametrosConexionDB;

        static SqlConnection conexion = new SqlConnection();
        public BaseDeDatos()
        {
            //esquema = System.Configuration.ConfigurationManager.AppSettings["esquema"];
            // parametrosConexionDB = @"Data Source=DESKTOP-NP4J7AB; Initial Catalog=TP_Diseño; Integrated Security=Yes"; // PARA PC DE JUAN
            //parametrosConexionDB = "Server=localhost\\SQLSERVER2012;Database=ProyectoEscuela;USER ID=gd;Password=gd2016";  //PARA PC DE GABRIEL
            //  parametrosConexionDB = "Server=localhost\\SQLSERVER2012;Database=GD1C2016;USER ID=gd;Password=gd2016";  //PARA PC DE TOMAS
        }
        private static string leerArch()
        {

            string rutaArch = @"C:\PC.txt";
            string texto;
            StreamReader leer = new StreamReader(rutaArch);
            texto = leer.ReadToEnd();
            return texto;
        }

        public static void abrirConexion()
        {
            string BD;
            BD = leerArch();
            ConnectionStringSettings parametros = ConfigurationManager.ConnectionStrings[BD];
            conexion.ConnectionString = parametros.ConnectionString;
            conexion.Open();
        }



        public SqlCommand obtenerStoredProcedure(String nombre)
        {
            abrirConexion();
            SqlCommand sp = new SqlCommand(nombre, conexion);
            sp.CommandType = CommandType.StoredProcedure;
            return sp;
        }

        public SqlCommand obtenerConsulta(String consulta)
        {
            abrirConexion();
            SqlCommand sp = new SqlCommand(consulta, conexion);
            return sp;
        }

    }
}