using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_disenio_1.Comandos;
using tp_disenio_1.Reportes;

namespace tp_disenio_1
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            AbmPois ap = new AbmPois();
            ap.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Reporte reporte = new Reporte();
            reporte.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuscarPOI fo = new BuscarPOI(this);
            fo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PruebaComandos pc = new PruebaComandos();
            pc.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ParametrosBusqueda pb = new ParametrosBusqueda();
            pb.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Inicio PantallaDeInicio = new Inicio();
            PantallaDeInicio.Show();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {

        }
    }
}
