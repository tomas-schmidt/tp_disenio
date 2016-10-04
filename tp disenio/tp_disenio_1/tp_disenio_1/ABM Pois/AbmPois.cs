using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_disenio_1.ABM_Pois;

namespace tp_disenio_1
{
    public partial class AbmPois : Form
    {
        public AbmPois()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AltaPois ap = new AltaPois();
            ap.Show();

        }

        private void AbmPois_Load(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ModificarPoi mp = new ModificarPoi();
            mp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Administrador ad = new Administrador();
            ad.Show(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Inicio PantallaDeInicio = new Inicio();
            PantallaDeInicio.Show();
        }

       
    }
}
