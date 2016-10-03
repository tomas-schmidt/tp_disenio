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
            AltaParada ap = new AltaParada();
            ap.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaLocal al = new AltaLocal();
            al.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AltaBanco ab = new AltaBanco();
            ab.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AltaCgp ac = new AltaCgp();
            ac.Show();
        }
    }
}
