using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetLight;

namespace PrototiposdeComedor
{
    public partial class Reportes : Form
    {
        OracleDataBaseConexion conexion = new OracleDataBaseConexion();
        public Reportes()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            label5.Text = "Hoy Es: " + Program.date;
            conexion.conect();
            DataSet ds = conexion.llenar("Select * from usuarios");
            DataSet ds1 = conexion.llenar("Select empresa from empresas");
            int i = 0;
            foreach (DataRow s in ds1.Tables[0].Rows)
            {

                String item = ds1.Tables[0].Rows[i]["empresa"].ToString();
                comboBox1.Items.Add(item);
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.conect();
            if (comboBox1.Text == "Todas")
            {
                String Querty;
                String Fecha1 = dateTimePicker1.Value + "";
                String Fecha2 = dateTimePicker2.Value + "";
                Fecha1 = Fecha1.Substring(0, 11);
                Fecha2 = Fecha2.Substring(0, 11);
                Querty = "SELECT nombre, empresa, TO_CHAR(FECHA_COMIDA,'DD-MM-YYYY'), precio_platillo from comensales, comidas where comensales.N_EMPLEADO = comidas.N_EMPLEADO AND FECHA_COMIDA BETWEEN '" + Fecha1 + "' AND '" + Fecha2 + "' ";
                DataSet ds = conexion.llenar(Querty);
                DataTable dt = ds.Tables[0];
                saveFileDialog1.ShowDialog();
                String Path = saveFileDialog1.FileName+ ".xlsx";
                SLDocument osl = new SLDocument();
                osl.ImportDataTable(1, 1, dt, true);
                osl.SaveAs(Path);
            }
            else
            {
                String Querty;
                String Fecha1 = dateTimePicker1.Value + "";
                String Fecha2 = dateTimePicker2.Value + "";
                Fecha1 = Fecha1.Substring(0, 11);
                Fecha2 = Fecha2.Substring(0, 11);
                Querty = "SELECT nombre, empresa, TO_CHAR(FECHA_COMIDA,'DD-MM-YYYY'), precio_platillo from comensales, comidas where comensales.N_EMPLEADO = comidas.N_EMPLEADO AND FECHA_COMIDA BETWEEN '" + Fecha1 + "' AND '" + Fecha2 + "' AND empresa = '" +comboBox1.Text +"'";
                DataSet ds = conexion.llenar(Querty);
                DataTable dt = ds.Tables[0];
                saveFileDialog1.ShowDialog();
                String Path = saveFileDialog1.FileName + ".xlsx";
                SLDocument osl = new SLDocument();
                osl.ImportDataTable(1, 1, dt, true);
                osl.SaveAs(Path);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal menuprincipal = new MenuPrincipal();
            menuprincipal.Show();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           
        }

        private void Reportes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
