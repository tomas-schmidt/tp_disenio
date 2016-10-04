using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace tp_disenio_1.Reportes
{
    public partial class Reporte : Form
    {
        
        public Reporte()
        {
            InitializeComponent();                        
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            
        }

        public void ProcesarConsulta(string texto, int cantidadResultados, int tiempoConsulta)
        {       
            BaseDeDatos bd = new BaseDeDatos();
            var spAgregarConsulta = bd.obtenerStoredProcedure("agregarConsulta");
            spAgregarConsulta.Parameters.Add("@texto", SqlDbType.VarChar).Value = texto;
            spAgregarConsulta.Parameters.Add("@cantidadResultados", SqlDbType.Int).Value = cantidadResultados;
            spAgregarConsulta.Parameters.Add("@tiempoConsulta", SqlDbType.Int).Value = tiempoConsulta;            
            spAgregarConsulta.ExecuteNonQuery();
            spAgregarConsulta.Connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spCantidadDeBusquedasPorFecha = bd.obtenerStoredProcedure("cantidadDeBusquedasPorFecha");
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = spCantidadDeBusquedasPorFecha;
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dbdataset.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["Fecha"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Cantidad busquedas"].ToString();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spresultadosParciales = bd.obtenerStoredProcedure("resultadosParciales");
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = spresultadosParciales;
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            dataGridView2.Rows.Clear();
            foreach (DataRow item in dbdataset.Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = item["usuario"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["Cantidad Resultados Parciales"].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spresultadosTotales = bd.obtenerStoredProcedure("resultadosTotales");
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = spresultadosTotales;
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            dataGridView3.Rows.Clear();
            foreach (DataRow item in dbdataset.Rows)
            {
                int n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = item["usuario"].ToString();
                dataGridView3.Rows[n].Cells[1].Value = item["Cantidad Resultados Totales"].ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            this.Close();
            Administrador ad = new Administrador();
            ad.Show(); 
        }
    }
}
