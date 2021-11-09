using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace PrototiposdeComedor
{
    public partial class Comensales : Form
    {
        OracleDataBaseConexion conexion = new OracleDataBaseConexion();
        public Comensales()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
        }

        private void Comensales_Load(object sender, EventArgs e)
        {
            conexion.conect();
            DataSet ds = conexion.llenar("Select * from comensales");
            dataGridView1.DataSource = ds.Tables[0];
            DataSet ds1 = conexion.llenar("Select empresa from empresas");
            int i = 0;
            foreach (DataRow s in ds1.Tables[0].Rows)
            {

                String item = ds1.Tables[0].Rows[i]["empresa"].ToString();
                comboBox1.Items.Add(item);
                i++;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String numeroEmpleado = richTextBox1.Text;
            String Nombre = richTextBox2.Text;
            String apellido = richTextBox3.Text;
            String Empresa = comboBox1.Text;
            String querty = "insert into comensales (N_EMPLEADO, NOMBRE, APELLIDO, EMPRESA) VALUES (" + numeroEmpleado + ", '" + Nombre + "','" + apellido + "','" + Empresa + "')";
            conexion.genericcmd(querty);
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            comboBox1.Text = "";
            DataSet ds = conexion.llenar("Select * from comensales");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String querty = "update comensales set N_EMPLEADO = '" + richTextBox1.Text + "' where N_EMPLEADO='" + label7.Text + "'";
            conexion.genericcmd(querty);
            label7.Text = richTextBox1.Text;
            querty = "update comensales set NOMBRE = '" + richTextBox2.Text + "' where N_EMPLEADO='" + label7.Text + "'";
            conexion.genericcmd(querty);
            querty = "update comensales set APELLIDO = '" + richTextBox3.Text + "' where N_EMPLEADO='" + label7.Text + "'";
            conexion.genericcmd(querty);
            querty = "update comensales set EMPRESA = '" + comboBox1.Text + "' where N_EMPLEADO='" + label7.Text + "'";
            conexion.genericcmd(querty);
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            comboBox1.Text = "";
            DataSet ds = conexion.llenar("Select * from comensales");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                String comensal = dataGridView1.SelectedCells[0].Value.ToString();
                DataSet ds = conexion.llenar("Select N_EMPLEADO,NOMBRE,APELLIDO,EMPRESA  from comensales where N_EMPLEADO = '" + comensal + "'");
                comensal = (ds.Tables[0].Rows[0]["N_EMPLEADO"]).ToString();
                richTextBox1.Text = comensal;
                string selected = comensal;
                label7.Text = selected;
                comensal = (ds.Tables[0].Rows[0]["EMPRESA"]).ToString();
                comboBox1.Text = comensal;
                comensal = (ds.Tables[0].Rows[0]["NOMBRE"]).ToString();
                richTextBox2.Text = comensal;
                comensal = (ds.Tables[0].Rows[0]["APELLIDO"]).ToString();
                richTextBox3.Text = comensal;
            }
            catch (Exception)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String querty = "delete from comensales where N_EMPLEADO= '" + label7.Text + "' and APELLIDO = '" + richTextBox3.Text + "'";
            conexion.genericcmd(querty);
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            comboBox1.Text = "";
            DataSet ds = conexion.llenar("Select * from comensales");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BarcodeWriter qr = new BarcodeWriter();
            qr.Format = BarcodeFormat.QR_CODE;
            Bitmap codigoqr = qr.Write(label7.Text);
            pictureBox3.Image = codigoqr;
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Filter = "JPEG(*.JPG)|*.JPG|BMP(*.BMP)|*.BMP";
            Image Imagen = pictureBox3.Image;
            Guardar.ShowDialog();
            Imagen.Save(Guardar.FileName);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
