using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_disenio_1;

namespace tp_disenio_1
{
    public partial class Logueador : Form
    {
        public Logueador()
        {
            InitializeComponent();
        }
        public bool logueado = false;
        private void Logueador_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            IniciarSesion();
        }
        public void IniciarSesion()
        {


            string resultado = Datos.IniciarSesion(txtNombre.Text, txtContraseña.Text);

            if (resultado != "")
            {
                logueado = true;

                MessageBox.Show(resultado, "Mensaje", MessageBoxButtons.OK);
                BaseDeDatos bd = new BaseDeDatos();
                var spGuardarUsuarioSesionActual = bd.obtenerStoredProcedure("GuardarUsuarioSesionActual");
                spGuardarUsuarioSesionActual.Parameters.Add("@usuario", SqlDbType.VarChar).Value = txtNombre.Text;
                spGuardarUsuarioSesionActual.ExecuteNonQuery();
                spGuardarUsuarioSesionActual.Connection.Close(); 
                Administrador ad =new Administrador();
                ad.Show();                
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Error", MessageBoxButtons.OK);
                txtNombre.Text = "";
                txtContraseña.Text = "";
                txtNombre.Focus();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
