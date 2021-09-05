﻿using Oracle.ManagedDataAccess.Client;
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
        OracleDataBaseConexion conexion = new OracleDataBaseConexion();
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
            this.Hide();
            Usuarios usuarios = new Usuarios();
            usuarios.Show();
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
            String sql = "Select privilegios from usuarios where usuario = 'SYSTEM'";
            conexion.conect();
            OracleCommand comando = new OracleCommand(sql, conexion);
            comando.CommandType = CommandType.Text;



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
