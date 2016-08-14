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
    public partial class AbmPois : Form
    {
        public AbmPois()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaPoi ap = new AltaPoi();
            ap.Show();

        }

        private void AbmPois_Load(object sender, EventArgs e)
        {
        
        }

       
    }
}
