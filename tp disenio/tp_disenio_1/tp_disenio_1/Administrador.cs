using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            AbmPois ap = new AbmPois();
            ap.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarPOI fo = new BuscarPOI();
            fo.Show();
        }
    }
}
