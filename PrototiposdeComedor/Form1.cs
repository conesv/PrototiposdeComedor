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
    public partial class Form1 : Form
    {
        OracleDataBaseConexion conexion = new OracleDataBaseConexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.conect();
                string user = conexion.comand("select usuario from usuarios where usuario = '"+textBox1.Text+"'");
                string password = conexion.comand("select password from usuarios where usuario = '" + textBox1.Text + "'");
                string privilegios = conexion.comand("select privilegios from usuarios where usuario = '" + textBox1.Text + "'");
            if (user == textBox1.Text && password == textBox2.Text)
                {
                if (privilegios == "1")
                {
                    Program.globales1 = "1";
                }
                else if (privilegios == "2")
                {
                    Program.globales1 = "2";
                }
                else
                {
                    Program.globales1 = "3";
                }
                MenuPrincipal menu = new MenuPrincipal();
                    Program.usuario = textBox1.Text;
                    this.Hide();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contrasña incorrecta");
                }
            }
            catch (Exception)
            {
                label3.Visible = true;
            }
           
        }
    }
}
