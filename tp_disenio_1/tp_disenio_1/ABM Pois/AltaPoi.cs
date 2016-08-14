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
    public partial class AltaPoi : Form
    {
        public AltaPoi()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int si1 = comboBox1.SelectedIndex;
            if ((string)comboBox1.Items[si1] == "Parada")
            {
                lbl_rubro.Hide();
                lbl_radio.Hide();
                lbl_comuna.Hide();
                lbl_numeroColectivo.Show();
                txt_radio.Hide();
                txt_rubro.Hide();
                txt_numeroColectivo.Show();
                txt_comuna.Hide();
                    

            }

            if ((string)comboBox1.Items[si1] == "Local")
            {
                lbl_rubro.Show();
                lbl_radio.Show();
                lbl_comuna.Hide();
                lbl_numeroColectivo.Hide();
                txt_radio.Show();
                txt_rubro.Show();
                txt_numeroColectivo.Hide();
                txt_comuna.Hide();


            }

            if ((string)comboBox1.Items[si1] == "CGP")
            {
                lbl_rubro.Hide();
                lbl_radio.Hide();
                lbl_comuna.Show();
                lbl_numeroColectivo.Hide();
                txt_radio.Hide();
                txt_rubro.Hide();
                txt_numeroColectivo.Hide();
                txt_comuna.Show();


            }

            if ((string)comboBox1.Items[si1] == "Banco")
            {
                lbl_rubro.Hide();
                lbl_radio.Hide();
                lbl_comuna.Hide();
                lbl_numeroColectivo.Hide();
                txt_radio.Hide();
                txt_rubro.Hide();
                txt_numeroColectivo.Hide();
                txt_comuna.Hide();


            }
        }

        private void AltaPoi_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Parada");
            comboBox1.Items.Add("Banco");
            comboBox1.Items.Add("Local");
            comboBox1.Items.Add("CGP");

            comboBox1.SelectedItem = comboBox1.Items[0];
            /*lbl_comuna.Visible = false;
            lbl_numeroColectivo.Visible = false;
            lbl_radio.Visible = false;
            lbl_rubro.Visible = false;
            txt_comuna.Visible = false;
            txt_numeroColectivo.Visible = false;
            txt_radio.Visible = false;
            txt_rubro.Visible = false;*/
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

        }
    }
}
