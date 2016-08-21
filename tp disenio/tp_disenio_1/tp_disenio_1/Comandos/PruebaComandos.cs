using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_disenio_1.Comandos
{
    public partial class PruebaComandos : Form
    {
        public PruebaComandos()
        {
            InitializeComponent();
        }

        private void btn_actualizarLocales_Click(object sender, EventArgs e)
        {
            ActualizarLocales al =  new ActualizarLocales(txt_actualizarLocales.Text);
            al.ejecutar();


        }

        private void btn_bajaPoi_Click(object sender, EventArgs e)
        {
            BajaDePois bdp = new BajaDePois(txt_bajaPoi.Text, dateTimePicker1.Value);
            bdp.ejecutar();

        }

        private void Comandos_Load(object sender, EventArgs e)
        {

        }
    }
}
