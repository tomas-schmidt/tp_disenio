using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace tp_disenio_1
{
    public class BaseDeDatos
    {
        public String parametrosConexionDB;
        

        public BaseDeDatos()
        {
            //parametrosConexionDB = "Server=" + System.Configuration.ConfigurationManager.AppSettings["server"] + ";"
            //    + "Database=" + System.Configuration.ConfigurationManager.AppSettings["database"] + ";"
            //    + "User ID=" + System.Configuration.ConfigurationManager.AppSettings["id"] + ";"
            //    + "Password=" + System.Configuration.ConfigurationManager.AppSettings["password"];

            //esquema = System.Configuration.ConfigurationManager.AppSettings["esquema"];




        parametrosConexionDB = "Server=localhost\\SQLSERVER2012;Database=ProyectoEscuela;USER ID=gd;Password=gd2016";  //PARA PC DE GABRIEL

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

