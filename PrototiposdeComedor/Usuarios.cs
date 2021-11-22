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
    public partial class Usuarios : Form
    {
        OracleDataBaseConexion conexion = new OracleDataBaseConexion();
        public Usuarios()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            conexion.conect();
            DataSet ds = conexion.llenar("Select USUARIO,PASSWORD,PRIVILEGIOS,EMAIL from usuarios");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            if (richTextBox1.Text.Length == 0)
            {
                label7.Visible = true;
            }
            else
            {
                if (richTextBox2.Text.Length == 0)
                {
                    label8.Visible = true;
                }
                else
                {
                    if (comboBox1.Text.Length == 0)
                    {
                        label9.Visible = true;
                    }
                    else
                    {
                        if (richTextBox3.Text.Length == 0)
                        {
                            label10.Visible = true;
                        }
                        else
                        {
                            Int32 permisos = comboBox1.SelectedIndex + 1;
                            Int32 id_usuario = Int32.Parse(conexion.comand("select max(id_usuario) from usuarios"));
                            id_usuario = id_usuario + 1;
                            String querty = "insert into usuarios (id_usuario, usuario, password, privilegios, email) values ("+id_usuario+", '" + richTextBox1.Text + "', '"+richTextBox3.Text + "',"+ permisos + ",'"+richTextBox2.Text +"')";
                            conexion.genericcmd(querty);
                            richTextBox1.Text = "";
                            richTextBox2.Text = "";
                            richTextBox3.Text = "";
                            comboBox1.SelectedIndex = 0;
                            DataSet ds = conexion.llenar("Select USUARIO,PASSWORD,PRIVILEGIOS,EMAIL from usuarios");
                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                }
            }            }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                label7.Visible = true;
            }
            else
            {
                if (richTextBox2.Text.Length == 0)
                {
                    label8.Visible = true;
                }
                else
                {
                    if (comboBox1.Text.Length == 0)
                    {
                        label9.Visible = true;
                    }
                    else
                    {
                        if (richTextBox3.Text.Length == 0)
                        {
                            label10.Visible = true;
                        }
                        else
                        {
                            String querty = "update usuarios set usuario = '"+richTextBox1.Text+"' where usuario='"+label11.Text+"'";
                            conexion.genericcmd(querty);
                            label11.Text = richTextBox1.Text;
                             querty = "update usuarios set EMAIL = '" + richTextBox2.Text + "' where usuario='" + label11.Text + "'";
                            conexion.genericcmd(querty);
                             querty = "update usuarios set PRIVILEGIOS = '" + comboBox1.SelectedIndex + "' where usuario='" + label11.Text + "'";
                            conexion.genericcmd(querty);
                             querty = "update usuarios set PASSWORD = '" + richTextBox3.Text + "' where usuario='" + label11.Text + "'";
                            conexion.genericcmd(querty);
                            richTextBox1.Text = "";
                            richTextBox2.Text = "";
                            richTextBox3.Text = "";
                            comboBox1.SelectedIndex = 0;
                            DataSet ds = conexion.llenar("Select USUARIO,PASSWORD,PRIVILEGIOS,EMAIL from usuarios");
                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
            try
            {
                String usuario = dataGridView1.SelectedCells[0].Value.ToString();
                DataSet ds = conexion.llenar("Select usuario,privilegios,email,password  from usuarios where usuario = '" + usuario + "'");
                usuario = (ds.Tables[0].Rows[0]["usuario"]).ToString();
                richTextBox1.Text = usuario;
                string selected = usuario;
                label11.Text = selected;
                usuario = (ds.Tables[0].Rows[0]["privilegios"]).ToString();
                comboBox1.SelectedIndex = Convert.ToInt32(usuario);
                usuario = (ds.Tables[0].Rows[0]["email"]).ToString();
                richTextBox2.Text = usuario;
                usuario = (ds.Tables[0].Rows[0]["password"]).ToString();
                richTextBox3.Text = usuario;
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String querty = "delete from usuarios where usuario= '"+ label11.Text+"' and password = '"+richTextBox3.Text+"'";
            conexion.genericcmd(querty);
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            comboBox1.SelectedIndex = 0;
            DataSet ds = conexion.llenar("Select USUARIO,PASSWORD,PRIVILEGIOS,EMAIL from usuarios");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Usuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
