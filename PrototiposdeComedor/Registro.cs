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
    public partial class Registro : Form
    {
        OracleDataBaseConexion conexion = new OracleDataBaseConexion();
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal menuprincipal = new MenuPrincipal();
            menuprincipal.Show();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            label1.Text = "Hoy es: " + Program.date;
            this.ActiveControl = Invisible;
            conexion.conect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String N_EMPLEADO = Invisible.Text;
            DataSet ds = conexion.llenar("Select N_EMPLEADO,NOMBRE,APELLIDO,EMPRESA  from comensales where N_EMPLEADO = '" + N_EMPLEADO + "'");
            N_EMPLEADO = (ds.Tables[0].Rows[0]["N_EMPLEADO"]).ToString();
            String id_empleado = (ds.Tables[0].Rows[0]["N_EMPLEADO"]).ToString();
            richTextBox1.Text = N_EMPLEADO;
            N_EMPLEADO = (ds.Tables[0].Rows[0]["EMPRESA"]).ToString();
            richTextBox3.Text = N_EMPLEADO;
            N_EMPLEADO = (ds.Tables[0].Rows[0]["NOMBRE"]).ToString() + " " + ds.Tables[0].Rows[0]["APELLIDO"].ToString();
            richTextBox2.Text = N_EMPLEADO;
            DataSet ds1 = conexion.llenar("select max(id_comida) from comidas");
            Int32 NuevoId = Int32.Parse((ds1.Tables[0].Rows[0]["MAX(id_comida)"]).ToString());
            int id = NuevoId + 1;
            String comando = "insert into comidas(id_comida, precio_platillo, fecha_comida, turno_comida, N_EMPLEADO, id_usuario)values("+ id+ ", 62, sysdate, 12,"+id_empleado+", 1)";
            conexion.genericcmd(comando);
            Invisible.Text = "";
            this.ActiveControl = Invisible;
        }

        private void Registro_Click(object sender, EventArgs e)
        {
            this.ActiveControl = Invisible;
        }

        private void Registro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
