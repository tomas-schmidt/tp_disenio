﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_disenio_1.Logueo
{
    public partial class LogueadorUsuario : Form
    {
        public LogueadorUsuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LogueadorUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spGuardarUsuarioSesionActual = bd.obtenerStoredProcedure("GuardarUsuarioSesionActual");
            spGuardarUsuarioSesionActual.Parameters.Add("@usuario", SqlDbType.VarChar).Value = textBox1.Text;
            spGuardarUsuarioSesionActual.ExecuteNonQuery();
            spGuardarUsuarioSesionActual.Connection.Close();                      
            BuscarPOI fo2 = new BuscarPOI();
            fo2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Inicio PantallaDeInicio = new Inicio();
            PantallaDeInicio.Show();
        }
    }
}
