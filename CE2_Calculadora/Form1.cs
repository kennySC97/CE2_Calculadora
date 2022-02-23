using CE2_Calculadora.modelos;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CE2_Calculadora
{
    public partial class formCalculadora : Form
    {

        private Funcionalidad funcionalidad;
        private bool enEjecucion = false;

        public formCalculadora()
        {
            InitializeComponent();
            funcionalidad = new Funcionalidad(0);
        }

        #region Metodos de caracteres

        private void btn_coma_Click(object sender, EventArgs e)
        {
            if (lbl_pantalla.Text.Length <= 9)
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

        }

        private void colocarNumero(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lbl_pantalla.Text.Length <= 9)
            {
                lbl_pantalla.Text += btn.Text;
            }
        }

        private void btn_signo_Click(object sender, EventArgs e)
        {            
            if (lbl_pantalla.Text.Contains("-"))
            {
                lbl_pantalla.Text = lbl_pantalla.Text.Remove(0, 1);
            }
            else if (lbl_pantalla.Text.Length > 0 && lbl_pantalla.Text.Length <= 10)
            {
                lbl_pantalla.Text = "-" + lbl_pantalla.Text;
            }         
        }

        #endregion

        #region Operaciones, borrado y memoria

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (lbl_pantalla.Text.Length > 0)
            {
                lbl_pantalla.Text = lbl_pantalla.Text.Remove(lbl_pantalla.Text.Length - 1);
            }
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text = "";
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text = "";
            lbl_log.Text = "";
            funcionalidad.cancelar();
        }

        private void setearOperacion(object sender, EventArgs e)
        {
            if (lbl_pantalla.Text.Length > 0 && funcionalidad.getOperacion() == "")
            {
                funcionalidad.setNumeroActivo(Convert.ToDecimal(lbl_pantalla.Text));
            }
            Button btn = (Button)sender;
            if (btn.Text == "MOD")
            {
                funcionalidad.setOperacion("mod");
            } 
            else
            {
                funcionalidad.setOperacion(btn.Text);
            }
            funcionalidad.generarLogOperacion("");
            lbl_log.Text = funcionalidad.getLogOperacion();
            lbl_pantalla.Text = "";
        }

        private void calcular(object sender, EventArgs e)
        {            
            funcionalidad.calcular(lbl_pantalla.Text.Length > 0 ? Convert.ToDecimal(lbl_pantalla.Text) : 0);
            lbl_log.Text = funcionalidad.getLogOperacion();

            lbl_pantalla.Text = funcionalidad.getNumeroPantalla();
        }

        private void btn_MC_Click(object sender, EventArgs e)
        {
            funcionalidad.borrarMemoria();
            cambiarEstadoBotonesMemoria(false);
            lbl_mem.Text = "Mem clear";
        }

        private void btn_MR_Click(object sender, EventArgs e)
        {
            lbl_pantalla.Text = funcionalidad.llamarMemoria().ToString();
        }

        private void btn_MS_Click(object sender, EventArgs e)
        {
            if (lbl_pantalla.Text.Length > 0)
            {
                funcionalidad.guardaMemoria(Convert.ToDecimal(lbl_pantalla.Text));
                cambiarEstadoBotonesMemoria(true);
                mostrarMemoria();
            }
        }

        private void btn_MSuma_Click(object sender, EventArgs e)
        {
            funcionalidad.sumarMemoria(Convert.ToDecimal(lbl_pantalla.Text));
            mostrarMemoria();
        }

        private void btn_MResta_Click(object sender, EventArgs e)
        {
            funcionalidad.restarMemoria(Convert.ToDecimal(lbl_pantalla.Text));
            mostrarMemoria();
        }

        #endregion

        #region funcionalidades miscelaneas

        public void cambiarEstadoBotonesMemoria(bool estado)
        {
            btn_MR.Enabled = estado;
            btn_MC.Enabled = estado;
            btn_MSuma.Enabled = estado;
            btn_MResta.Enabled = estado;
        }

        public void mostrarMemoria()
        {
            lbl_mem.Text = $"Mem {funcionalidad.llamarMemoria().ToString()}";
        }

        #endregion

        #region Manejador de Atajos del Teclado             

        private void manejadorAtajos(object sender, KeyEventArgs e)
        {            
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.L:
                        btn_MC.PerformClick();
                        break;
                    case Keys.R:
                        btn_MR.PerformClick();
                        break;
                    case Keys.M:
                        btn_MS.PerformClick();
                        break;
                    case Keys.P:
                        btn_MSuma.PerformClick();
                        break;
                    case Keys.Q:
                        btn_MResta.PerformClick();
                        break;
                    case Keys.Enter:
                        btn_igual.PerformClick();
                        break;
                    default:
                        break;
                }
            }   
            else
            {

                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        btn_CE.PerformClick();
                        break;
                    case Keys.Escape:
                        btn_C.PerformClick();
                        break;
                    case Keys.NumPad0:
                        btn_cero.PerformClick();
                        break;
                    case Keys.NumPad1:
                        btn_uno.PerformClick();
                        break;
                    case Keys.NumPad2:
                        btn_dos.PerformClick();
                        break;
                    case Keys.NumPad3:
                        btn_tres.PerformClick();
                        break;
                    case Keys.NumPad4:
                        btn_cuatro.PerformClick();
                        break;
                    case Keys.NumPad5:
                        btn_cinco.PerformClick();
                        break;
                    case Keys.NumPad6:
                        btn_seis.PerformClick();
                        break;
                    case Keys.NumPad7:
                        btn_siete.PerformClick();
                        break;
                    case Keys.NumPad8:
                        btn_ocho.PerformClick();
                        break;
                    case Keys.NumPad9:
                        btn_nueve.PerformClick();
                        break;
                    case Keys.Decimal:
                        btn_coma.PerformClick();
                        break;
                    case Keys.Add:
                        btn_suma.PerformClick();
                        break;
                    case Keys.Subtract:
                        btn_resta.PerformClick();
                        break;
                    case Keys.Multiply:
                        btn_multiplicacion.PerformClick();
                        break;
                    case Keys.Divide:
                        btn_division.PerformClick();
                        break;
                    case Keys.Back:
                        btn_borrar.PerformClick();
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion        
    }
}
