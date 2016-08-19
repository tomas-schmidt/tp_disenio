using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_disenio_1.Logueo;

namespace tp_disenio_1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logueador lo = new Logueador();
            lo.Show();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogueadorUsuario lo2 = new LogueadorUsuario();
            lo2.Show();
        }
    }
}
