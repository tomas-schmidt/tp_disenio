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
    public partial class AltaPois : Form
    {
        public AltaPois()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AltaParada ap = new AltaParada();
            ap.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            AltaLocal al = new AltaLocal();
            al.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AltaBanco ab = new AltaBanco();
            ab.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            AltaCgp ac = new AltaCgp();
            ac.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {                            
            this.Close();
            AbmPois ad =new AbmPois();
            ad.Show(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Inicio PantallaDeInicio = new Inicio();
            PantallaDeInicio.Show();
        }
    }
}
