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
    public partial class AltaParada : Form
    {
        public AltaParada()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spCrearParada = bd.obtenerStoredProcedure("crearParada");
            spCrearParada.Parameters.Add("@longitud", SqlDbType.Float).Value = Convert.ToDouble(txt_longitud.Text);
            spCrearParada.Parameters.Add("@latitud", SqlDbType.Float).Value = Convert.ToDouble(txt_latitud.Text);
            spCrearParada.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txt_nombre.Text;
            spCrearParada.Parameters.Add("@numeroParada", SqlDbType.Int).Value = Convert.ToInt32(txt_numero.Text);
            spCrearParada.Parameters.Add("@direccion", SqlDbType.VarChar).Value = txt_direccion.Text;

            spCrearParada.ExecuteNonQuery();

            spCrearParada.Connection.Close();
            MessageBox.Show("Nueva parada cargada");
            this.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            AltaPois ad = new AltaPois();
            ad.Show(); 
        }
    }
}
