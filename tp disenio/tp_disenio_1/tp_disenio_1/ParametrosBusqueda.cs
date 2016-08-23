using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_disenio_1
{
    public partial class ParametrosBusqueda : Form
    {
        private string mail;
	    private int tiempoMaxBusqueda;  

        public ParametrosBusqueda()
        {
            InitializeComponent();
        }

        private void ParametrosBusqueda_Load(object sender, EventArgs e)
        {

            BaseDeDatos bd = new BaseDeDatos();
            var spobtenerParametrosBusqueda = bd.obtenerStoredProcedure("obtenerParametrosBusqueda");
            spobtenerParametrosBusqueda.Parameters.Add("@mail", SqlDbType.VarChar).Value = mail;

            //SqlParameter parameter = new SqlParameter();
            //parameter.ParameterName = "@CategoryName";
            parameter.SqlDbType = SqlDbType.NVarChar;
            spobtenerParametrosBusqueda.Direction = ParameterDirection.Input;
            parameter.Value = categoryName;

            spobtenerParametrosBusqueda.Parameters.Add("@tiempoMaxBusqueda", SqlDbType.Int).Value = tiempoMaxBusqueda;
            spobtenerParametrosBusqueda.ExecuteNonQuery();
            spobtenerParametrosBusqueda.Connection.Close();

            textBox1.Text= mail;
            textBox2.Text = tiempoMaxBusqueda.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
