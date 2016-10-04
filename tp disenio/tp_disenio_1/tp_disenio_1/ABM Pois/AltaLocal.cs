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

namespace tp_disenio_1.ABM_Pois
{
    public partial class AltaLocal : Form
    {
        public AltaLocal()
        {
            InitializeComponent();
        }

        private void AltaLocal_Load(object sender, EventArgs e)
        {
            this.cargarTabla();
        }

        private void cargarTabla()
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spObtenerRubros = bd.obtenerStoredProcedure("obtenerRubros");

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = spObtenerRubros;
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            foreach (DataRow item in dbdataset.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "false";
                dataGridView1.Rows[n].Cells[1].Value = item["descripcion"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["id_rubro"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spCrearLocal = bd.obtenerStoredProcedure("crearLocal");
            spCrearLocal.Parameters.Add("@longitud", SqlDbType.Float).Value = Convert.ToDouble(txt_longitud.Text);
            spCrearLocal.Parameters.Add("@latitud", SqlDbType.Float).Value = Convert.ToDouble(txt_latitud.Text);
            spCrearLocal.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txt_nombre.Text;
            spCrearLocal.Parameters.Add("@radioCercania", SqlDbType.Int).Value = txt_radio.Text;
            spCrearLocal.Parameters.Add("@direccion", SqlDbType.VarChar).Value = txt_direccion.Text;
            
            spCrearLocal.Parameters.Add("@horaInicio1", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial1.Text);
            spCrearLocal.Parameters.Add("@horaFin1", SqlDbType.Float).Value = Convert.ToDouble(txt_final1.Text);

            spCrearLocal.Parameters.Add("@horaInicio2", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial2.Text);
            spCrearLocal.Parameters.Add("@horaFin2", SqlDbType.Float).Value = Convert.ToDouble(txt_final2.Text);

            spCrearLocal.Parameters.Add("@horaInicio3", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial3.Text);
            spCrearLocal.Parameters.Add("@horaFin3", SqlDbType.Float).Value = Convert.ToDouble(txt_final3.Text);

            spCrearLocal.Parameters.Add("@horaInicio4", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial4.Text);
            spCrearLocal.Parameters.Add("@horaFin4", SqlDbType.Float).Value = Convert.ToDouble(txt_final4.Text);

            spCrearLocal.Parameters.Add("@horaInicio5", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial5.Text);
            spCrearLocal.Parameters.Add("@horaFin5", SqlDbType.Float).Value = Convert.ToDouble(txt_final5.Text);

            spCrearLocal.Parameters.Add("@horaInicio6", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial6.Text);
            spCrearLocal.Parameters.Add("@horaFin6", SqlDbType.Float).Value = Convert.ToDouble(txt_final6.Text);

            spCrearLocal.Parameters.Add("@horaInicio7", SqlDbType.Float).Value = Convert.ToDouble(txt_inicial7.Text);
            spCrearLocal.Parameters.Add("@horaFin7", SqlDbType.Float).Value = Convert.ToDouble(txt_final7.Text);


            var reader = spCrearLocal.ExecuteReader();
            reader.Read();
            int idLocal = int.Parse(reader[0].ToString());

           
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (bool.Parse(item.Cells[0].Value.ToString()))
                    {
                        var spAgregarRubroALocal = bd.obtenerStoredProcedure("agregarRubroALocal");
                        spAgregarRubroALocal.Parameters.Add("@id_rubro", SqlDbType.Int).Value = Convert.ToInt32(item.Cells[2].Value);
                        spAgregarRubroALocal.Parameters.Add("@id_local", SqlDbType.Int).Value = idLocal;
                        spAgregarRubroALocal.ExecuteNonQuery();
                        spAgregarRubroALocal.Connection.Close();
                    }
                }


                spCrearLocal.Connection.Close();
                MessageBox.Show("Nuevo Local cargado");
                this.Close();
            

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            AltaPois ad = new AltaPois();
            ad.Show(); 
        }
        }
}

