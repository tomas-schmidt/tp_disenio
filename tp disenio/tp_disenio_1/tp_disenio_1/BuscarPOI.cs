using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_disenio_1.Reportes;
using tp_disenio_1.Logueo;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;


namespace tp_disenio_1
{
    public partial class BuscarPOI : Form
    {
        bool llamadoDesdeAdministrador = false;
        public BuscarPOI()
        {
            InitializeComponent();
        }

        public BuscarPOI(Administrador ad)
        {
            llamadoDesdeAdministrador = true;
            InitializeComponent();
        }

        //CatalogoPois catalogo = CatalogoPois.Instance();
        CatalogoPois catalogo;
        HorarioDeAtencion lunesAVierner9a18;
        Parada parada114;
        Servicio unServicio;
        Banco bancoSantander;
        CGP comuna2;
        Local libreria;

        RepositorioComandos comandos = RepositorioComandos.Instance();
        public bool UsuarioLogueado = false;
        private void Form1_Load(object sender, EventArgs e)
        {            
            //this.Hide();                  NO HACE FALTA LOGUEAR ACÁ
            //Logueador login = new Logueador();
            //login.ShowDialog();
            //if (login.logueado == true)
            //{
            //    this.Show();
            //    UsuarioLogueado = true;
            //}
            //else
            //{
            //    this.Close();
            //}

            BaseDeDatos bd = new BaseDeDatos();
            var spresultadosPorUsuario = bd.obtenerStoredProcedure("resultadosPorUsuario");
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = spresultadosPorUsuario;
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            dataGridView2.Rows.Clear();
            foreach (DataRow item in dbdataset.Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = item["texto"].ToString();                
            }

            ////////////////////////////// PRUEBAS /////////////////////////////////////////

            //creamos algunos objetos

            catalogo = new CatalogoPois();

            /*
            lunesAVierner9a18 = new HorarioDeAtencion(new Tuple<int, int>[]{
                new Tuple<int,int>(0,0),
                new Tuple<int,int>(9,18),
                new Tuple<int,int>(9,18),
                new Tuple<int,int>(9,18),
                new Tuple<int,int>(9,18),
                new Tuple<int,int>(9,18),
                new Tuple<int,int>(0,0),
            });

            parada114 = new Parada(6, 8, "parada del 114", "avellaneda 367", lunesAVierner9a18, "114");

            unServicio = new Servicio("unServicio", lunesAVierner9a18);

            List<Servicio> listaServicios = new List<Servicio>();
            listaServicios.Add(unServicio);

            HashSet<string> rubros = new HashSet<string>();
            rubros.Add("libreria");

            comuna2 = new CGP(5, 3, "comuna numero 2", "av cordoba 1000", lunesAVierner9a18, 2, listaServicios);

            libreria = new Local(1, 2, "libreria escolar", "medrano 1200", lunesAVierner9a18, rubros , 500);

            bancoSantander = new Banco(6, 9, "banco santander", "lavalle 1502", lunesAVierner9a18);
  
            catalogo.agregarPoi(parada114);
            catalogo.agregarPoi(bancoSantander);
            catalogo.agregarPoi(libreria);
            catalogo.agregarPoi(comuna2);
            ////////////////////////////// PRUEBAS /////////////////////////////////////////
            */
        }


        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<Poi> listaPois = catalogo.buscar(txt_TextoBuscado.Text);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            int tiempoConsulta = ts.Milliseconds;         

            Reporte reporte = new Reporte();
            reporte.ProcesarConsulta(txt_TextoBuscado.Text, listaPois.Count(), tiempoConsulta);

            if (tiempoConsulta>2)
            {
                //this.EnviarMail(txt_TextoBuscado.Text);
            }

            foreach (Poi poi in listaPois)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = poi.obtenerNombre();
                dataGridView1.Rows[n].Cells[1].Value = poi.obtenerDireccion();
                dataGridView1.Rows[n].Cells[2].Value = poi.obtenerLatitud();
                dataGridView1.Rows[n].Cells[3].Value = poi.obtenerLongitud();
            }
            listaPois.Clear();
            txt_TextoBuscado.Clear();

        }



        public void EnviarMail(string textoDemorado)
        {

            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress("gaby_filipe@hotmail.com"));    
            email.From = new MailAddress("gabriel_prueba00@hotmail.com");
            email.Subject = "Demora en la busqueda ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.Body = "La busqueda del texto:" + textoDemorado + "esta tardando mas de lo esperado.";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp-mail.outlook.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("gabriel_prueba00@hotmail.com", "123prueba");

            string output = null;

            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }

            //MessageBox.Show(output, "My Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

         


        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Poi> listaPois = catalogo.lista();
            foreach (Poi poi in listaPois)
            {
                //if (poi.estaCercaDe(Convert.ToDouble(txt_latitud.Text), Convert.ToDouble(txt_longitud.Text)))
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = poi.obtenerNombre();
                    dataGridView1.Rows[n].Cells[1].Value = poi.obtenerDireccion();
                    dataGridView1.Rows[n].Cells[2].Value = poi.obtenerLatitud();
                    dataGridView1.Rows[n].Cells[3].Value = poi.obtenerLongitud();
                }
            }
            txt_latitud.Clear();
            txt_longitud.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Poi> listaPois = catalogo.lista();
            foreach (Poi poi in listaPois)
            {
                if (poi.estaDisponible(dateTimePicker1.Value, txt_disponibilidad.Text))
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = poi.obtenerNombre();
                    dataGridView1.Rows[n].Cells[1].Value = poi.obtenerDireccion();
                    dataGridView1.Rows[n].Cells[2].Value = poi.obtenerLatitud();
                    dataGridView1.Rows[n].Cells[3].Value = poi.obtenerLongitud();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btn_abmPois_Click(object sender, EventArgs e)
        {
            AbmPois ap = new AbmPois();
            ap.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void but_gestion_poi_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.Show();
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            this.EnviarMail("114");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Inicio PantallaDeInicio = new Inicio();
            PantallaDeInicio.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (llamadoDesdeAdministrador)
            {
                this.Close();
                Administrador ad = new Administrador();
                ad.Show(); 
            }
            else
            {
                this.Close();
                LogueadorUsuario log = new LogueadorUsuario();
                log.Show(); 
            }


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string columna1 = string.Empty;

            DataGridViewRow fila = dataGridView2.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView

            columna1 = Convert.ToString(fila.Cells[0].Value); //obtengo el valor de la primer columna

            txt_TextoBuscado.Text = columna1;

            button3_Click(sender,e);

            columna1 = string.Empty;

            txt_TextoBuscado.Text = "";
                

        }

        private void txt_TextoBuscado_TextChanged(object sender, EventArgs e)
        {

        }           

    }
}
