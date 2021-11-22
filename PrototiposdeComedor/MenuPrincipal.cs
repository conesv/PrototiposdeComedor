using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototiposdeComedor
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void UsuariosPB_Click(object sender, EventArgs e)
        {
            if (Program.globales1 == "1") {
                this.Hide();
                Usuarios usuarios = new Usuarios();
                usuarios.Show();
            }
              else
            {
                MessageBox.Show("inicie sesion como administrador");
            }
        }

        private void EmpleadosPB_Click(object sender, EventArgs e)
        {
            this.Hide();
            Comensales comensales = new Comensales();
            comensales.Show();
        }

        private void RegistroPB_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registro registro = new Registro();
            registro.Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            label3.Text = Program.usuario;
            if (Program.globales1.Equals("3"))
            {
                UsuariosPB.Enabled = false;
                ConfiguracionPB.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SalirPB_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConfiguracionPB_Click(object sender, EventArgs e)
        {
            this.Hide();
            Configuracion configuracion = new Configuracion();
            configuracion.Show();
        }

        private void ReportesPB_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reportes reportes = new Reportes();
            reportes.Show();
        }

        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
