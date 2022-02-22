using CE2_Calculadora.modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CE2_Calculadora
{
    public partial class formCalculadora : Form
    {

        private Funcionalidad funcionalidad;

        public formCalculadora()
        {
            InitializeComponent();
            funcionalidad = new Funcionalidad(0);
        }

        //#region Metodos de caracteres
        private void btn_coma_Click(object sender, EventArgs e)
        {            

            if (lbl_pantalla.Text.Length <= 0)
            {
                lbl_pantalla.Text = "0,";
            }
            else if (!lbl_pantalla.Text.Contains(","))
            {
                lbl_pantalla.Text += ",";
            }

        }

        private void btn_cero_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text += "0";
        }

        private void btn_uno_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text += "1";
        }

        private void btn_dos_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text += "2";
        }

        private void btn_tres_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text += "3";
        }

        private void btn_cuatro_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text += "4";
        }

        private void btn_cinco_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text += "5";
        }

        private void btn_seis_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text += "6";
        }

        private void btn_siete_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text += "7";
        }

        private void btn_ocho_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text += "8";
        }

        private void btn_nueve_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text += "9";
        }
    }
}
