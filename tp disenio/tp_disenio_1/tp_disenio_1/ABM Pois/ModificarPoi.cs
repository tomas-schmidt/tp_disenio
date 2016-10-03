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
    public partial class ModificarPoi : Form
    {
        public ModificarPoi()
        {
            InitializeComponent();
        }

        private void ModificarPoi_Load(object sender, EventArgs e)
        {
            this.cargarTabla();
        }

        private void cargarTabla()
        {
            BaseDeDatos bd = new BaseDeDatos();
            var spObtenerPois = bd.obtenerStoredProcedure("obtenerPois");

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = spObtenerPois;
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            foreach (DataRow item in dbdataset.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["nombre"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["latitud"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["longitud"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["direccion"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = "Alta/Baja";
                dataGridView1.Rows[n].Cells[6].Value = item["id_poi"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = (bool)item["habilitado"];

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && (e.RowIndex != -1))
            {
                BaseDeDatos bd = new BaseDeDatos();
                var spAltaYBajaPoi = bd.obtenerStoredProcedure("altaYBajaPoi");
                spAltaYBajaPoi.Parameters.Add("@id_poi", SqlDbType.VarChar).Value = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                spAltaYBajaPoi.ExecuteNonQuery();
                spAltaYBajaPoi.Connection.Close();
                MessageBox.Show("El POI fue dado de alta/baja");
                dataGridView1.Rows.Clear();
                this.cargarTabla();
            }
        }
    }
}
