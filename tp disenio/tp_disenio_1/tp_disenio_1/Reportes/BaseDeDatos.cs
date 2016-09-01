//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Data;
//using System.IO;

//namespace tp_disenio_1
//{
//    public class BaseDeDatos
//    {
//        public String parametrosConexionDB;

//        static SqlConnection conexion = new SqlConnection();
//        public BaseDeDatos()
//        {
            
//        }
//        private static string leerArch()
//        {

//            string rutaArch = @"C:\PC.txt";
//            string texto;
//            StreamReader leer = new StreamReader(rutaArch);
//            texto = leer.ReadToEnd();
//            return texto;
//        }

//        public static void abrirConexion()
//        {
//            if (conexion.State == System.Data.ConnectionState.Closed)
//            {
//                string BD;
//                BD = leerArch();
//                ConnectionStringSettings parametros = ConfigurationManager.ConnectionStrings[BD];
//                conexion.ConnectionString = parametros.ConnectionString;
//                conexion.Open();  
//            }                 
//        }

//        public SqlCommand obtenerStoredProcedure(String nombre)
//        {
//            abrirConexion();
//            SqlCommand sp = new SqlCommand(nombre, conexion);
//            sp.CommandType = CommandType.StoredProcedure;
//            return sp;
//        }

//        public SqlCommand obtenerConsulta(String consulta)
//        {
//            abrirConexion();
//            SqlCommand sp = new SqlCommand(consulta, conexion);
//            return sp;
//        }

//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.IO;

namespace tp_disenio_1
{
    public class BaseDeDatos
    {
        public String parametrosConexionDB;

        private static string leerArch()
        {

            string rutaArch = @"C:\PC.txt"; //PONER EN ARCHIVO PC EL STRING DE CONEXION DE CADA UNO
            string texto;
            StreamReader leer = new StreamReader(rutaArch);
            texto = leer.ReadToEnd();
            return texto;
        }

        public BaseDeDatos()
        {
            //PONER EN ARCHIVO "PC" EL STRING DE CONEXION DE CADA UNO
            //Data Source=DESKTOP-NP4J7AB; Initial Catalog=TP_Diseño; Integrated Security=Yes // PARA PC DE JUAN
            //Server=localhost\\SQLSERVER2012;Database=GD1C2016;USER ID=gd;Password=gd2016  //PARA PC DE TOMAS

            parametrosConexionDB = leerArch(); 

        }

        public SqlCommand obtenerStoredProcedure(String nombre)
        {
            SqlConnection conexion = new SqlConnection(parametrosConexionDB);
            conexion.Open();
            SqlCommand sp = new SqlCommand(nombre, conexion);
            sp.CommandType = CommandType.StoredProcedure;
            return sp;
        }

        public SqlCommand obtenerConsulta(String consulta)
        {
            SqlConnection conexion = new SqlConnection(parametrosConexionDB);
            conexion.Open();
            SqlCommand sp = new SqlCommand(consulta, conexion);
            return sp;
        }

    }
}
