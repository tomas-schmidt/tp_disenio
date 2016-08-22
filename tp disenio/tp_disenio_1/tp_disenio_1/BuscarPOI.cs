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
    public partial class BuscarPOI : Form
    {
        public BuscarPOI()
        {
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
            ////////////////////////////// PRUEBAS /////////////////////////////////////////

            //creamos algunos objetos

            catalogo = new CatalogoPois();


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
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DateTime inicio = DateTime.Now;
            int inicioSecond = inicio.Second;

            List<Poi> listaPois = catalogo.buscar(txt_TextoBuscado.Text);

            DateTime fin = DateTime.Now;
            int finSecond = fin.Second;
            int tiempoConsulta = inicioSecond - finSecond;

            Reporte reporte = new Reporte();
            reporte.ProcesarConsulta(txt_TextoBuscado.Text, listaPois.Count(), tiempoConsulta); 

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Poi> listaPois = catalogo.lista();
            foreach (Poi poi in listaPois)
            {
                if (poi.estaCercaDe(Convert.ToDouble(txt_latitud.Text), Convert.ToDouble(txt_longitud.Text)))
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


    }
}
