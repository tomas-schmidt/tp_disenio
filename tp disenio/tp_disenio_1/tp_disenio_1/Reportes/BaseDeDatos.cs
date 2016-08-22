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

         //   parametrosConexionDB = @"Data Source=DESKTOP-NP4J7AB; Initial Catalog=TP_Diseño; Integrated Security=Yes"; // PARA PC DE JUAN
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

