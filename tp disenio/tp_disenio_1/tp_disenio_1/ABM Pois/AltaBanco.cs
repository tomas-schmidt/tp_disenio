using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_disenio_1.ABM_Pois
{
    public partial class AltaBanco : Form
    {
        public AltaBanco()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spCrearBanco = bd.obtenerStoredProcedure("crearBanco");
            spCrearBanco.Parameters.Add("@longitud", SqlDbType.Float).Value = Convert.ToDouble(txt_longitud.Text);
            spCrearBanco.Parameters.Add("@latitud", SqlDbType.Float).Value = Convert.ToDouble(txt_latitud.Text);
            spCrearBanco.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txt_nombre.Text;
            spCrearBanco.Parameters.Add("@direccion", SqlDbType.VarChar).Value = txt_direccion.Text;

            spCrearBanco.Parameters.Add("@horaInicio1", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial1.Text);
            spCrearBanco.Parameters.Add("@horaFin1", SqlDbType.Float).Value = Convert.ToDouble(txt_final1.Text);

            spCrearBanco.Parameters.Add("@horaInicio2", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial2.Text);
            spCrearBanco.Parameters.Add("@horaFin2", SqlDbType.Float).Value = Convert.ToDouble(txt_final2.Text);

            spCrearBanco.Parameters.Add("@horaInicio3", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial3.Text);
            spCrearBanco.Parameters.Add("@horaFin3", SqlDbType.Float).Value = Convert.ToDouble(txt_final3.Text);

            spCrearBanco.Parameters.Add("@horaInicio4", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial4.Text);
            spCrearBanco.Parameters.Add("@horaFin4", SqlDbType.Float).Value = Convert.ToDouble(txt_final4.Text);

            spCrearBanco.Parameters.Add("@horaInicio5", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial5.Text);
            spCrearBanco.Parameters.Add("@horaFin5", SqlDbType.Float).Value = Convert.ToDouble(txt_final5.Text);

            spCrearBanco.Parameters.Add("@horaInicio6", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial6.Text);
            spCrearBanco.Parameters.Add("@horaFin6", SqlDbType.Float).Value = Convert.ToDouble(txt_final6.Text);

            spCrearBanco.Parameters.Add("@horaInicio7", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial7.Text);
            spCrearBanco.Parameters.Add("@horaFin7", SqlDbType.Float).Value = Convert.ToDouble(txt_final7.Text);


            spCrearBanco.ExecuteNonQuery();

            spCrearBanco.Connection.Close();
            MessageBox.Show("Nuevo banco cargado");
            this.Close();
        }
    }
}
