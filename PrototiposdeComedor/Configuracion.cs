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
    public partial class Configuracion : Form
    {
        OracleDataBaseConexion conexion = new OracleDataBaseConexion();
        public Configuracion()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = conexion.llenar("select max(id_empresa) from empresas");
            String Empresa = textBox1.Text;
            Int32 NuevoId = Int32.Parse((ds.Tables[0].Rows[0]["MAX(id_empresa)"]).ToString());
            int id = NuevoId + 1; 
            String Querty = "insert into empresas (id_empresa, empresa) values ("+id+",'"+Empresa+"')";
            conexion.genericcmd(Querty);
            DataSet ds1 = conexion.llenar("Select empresa from empresas");
            dataGridView1.DataSource = ds1.Tables[0];
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            conexion.conect();
            DataSet ds1 = conexion.llenar("Select empresa from empresas");
            dataGridView1.DataSource = ds1.Tables[0];

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal menuprincipal = new MenuPrincipal();
            menuprincipal.Show();
        }

        private void Configuracion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
