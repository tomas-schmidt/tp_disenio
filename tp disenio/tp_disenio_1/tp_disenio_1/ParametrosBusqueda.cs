﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_disenio_1
{
    public partial class ParametrosBusqueda : Form
    {
        
        public ParametrosBusqueda()
        {
            InitializeComponent();
        }

        private void ParametrosBusqueda_Load(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spObtenerParametrosBusqueda = bd.obtenerStoredProcedure("obtenerParametrosBusqueda");
            var reader = spObtenerParametrosBusqueda.ExecuteReader();
            reader.Read();
            string mail = reader[0].ToString();
            //reader.Read();
            int tiempoMaxBusqueda = Convert.ToInt32(reader[1]);
            textBox1.Text = mail;
            textBox2.Text = Convert.ToString(tiempoMaxBusqueda); 
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spguardarParametrosBusqueda = bd.obtenerStoredProcedure("guardarParametrosBusqueda");
            spguardarParametrosBusqueda.Parameters.Add("@mail", SqlDbType.VarChar).Value = textBox1.Text;
            spguardarParametrosBusqueda.Parameters.Add("@tiempoMaxBusqueda", SqlDbType.VarChar).Value = textBox2.Text;            
            spguardarParametrosBusqueda.ExecuteNonQuery();
            spguardarParametrosBusqueda.Connection.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
