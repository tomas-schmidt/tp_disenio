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


namespace tp_disenio_1.ABM_Pois
{
    public partial class AltaCgp : Form
    {
        public AltaCgp()
        {
            InitializeComponent();
        }

        private void AltaCgp_Load(object sender, EventArgs e)
        {
            this.cargarTabla();
        }

        private void cargarTabla()
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spObtenerServicios = bd.obtenerStoredProcedure("obtenerServicios");

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = spObtenerServicios;
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            foreach (DataRow item in dbdataset.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "false";
                dataGridView1.Rows[n].Cells[1].Value = item["descripcion"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["id_servicio"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spCrearCgp = bd.obtenerStoredProcedure("crearCgp");
            spCrearCgp.Parameters.Add("@longitud", SqlDbType.Float).Value = Convert.ToDouble(txt_longitud.Text);
            spCrearCgp.Parameters.Add("@latitud", SqlDbType.Float).Value = Convert.ToDouble(txt_latitud.Text);
            spCrearCgp.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txt_nombre.Text;
            spCrearCgp.Parameters.Add("@comuna", SqlDbType.Int).Value = txt_comuna.Text;
            spCrearCgp.Parameters.Add("@direccion", SqlDbType.VarChar).Value = txt_direccion.Text;
            
            spCrearCgp.Parameters.Add("@horaInicio1", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial1.Text);
            spCrearCgp.Parameters.Add("@horaFin1", SqlDbType.Float).Value = Convert.ToDouble(txt_final1.Text);

            spCrearCgp.Parameters.Add("@horaInicio2", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial2.Text);
            spCrearCgp.Parameters.Add("@horaFin2", SqlDbType.Float).Value = Convert.ToDouble(txt_final2.Text);

            spCrearCgp.Parameters.Add("@horaInicio3", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial3.Text);
            spCrearCgp.Parameters.Add("@horaFin3", SqlDbType.Float).Value = Convert.ToDouble(txt_final3.Text);

            spCrearCgp.Parameters.Add("@horaInicio4", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial4.Text);
            spCrearCgp.Parameters.Add("@horaFin4", SqlDbType.Float).Value = Convert.ToDouble(txt_final4.Text);

            spCrearCgp.Parameters.Add("@horaInicio5", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial5.Text);
            spCrearCgp.Parameters.Add("@horaFin5", SqlDbType.Float).Value = Convert.ToDouble(txt_final5.Text);

            spCrearCgp.Parameters.Add("@horaInicio6", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial6.Text);
            spCrearCgp.Parameters.Add("@horaFin6", SqlDbType.Float).Value = Convert.ToDouble(txt_final6.Text);

            spCrearCgp.Parameters.Add("@horaInicio7", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial7.Text);
            spCrearCgp.Parameters.Add("@horaFin7", SqlDbType.Float).Value = Convert.ToDouble(txt_final7.Text);


            var reader = spCrearCgp.ExecuteReader();
            reader.Read();
            int idCgp = int.Parse(reader[0].ToString());

            try
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (bool.Parse(item.Cells[0].Value.ToString()))
                    {
                        var spAgregarServicioACgp = bd.obtenerStoredProcedure("agregarServicioACgp");
                        spAgregarServicioACgp.Parameters.Add("@id_servicio", SqlDbType.Int).Value = Convert.ToInt32(item.Cells[2].Value);
                        spAgregarServicioACgp.Parameters.Add("@id_cgp", SqlDbType.Int).Value = idCgp;
                        spAgregarServicioACgp.ExecuteNonQuery();
                        spAgregarServicioACgp.Connection.Close();
                    }
                }


                spCrearCgp.Connection.Close();
                MessageBox.Show("Nuevo Cgp cargado");
                this.Close();
                AbmPois ab = new AbmPois();
                ab.Show();
            }

            catch (SqlException excepcion)
            {
                MessageBox.Show(excepcion.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            AltaPois ad = new AltaPois();
            ad.Show(); 
        }
    }
}
