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
using System.Data.Sql;

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
            //BuscarPOI bp = new BuscarPOI();
            //bp.Show();
            LogueadorUsuario lo2 = new LogueadorUsuario();
            lo2.Show();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }       
        
    }
}
