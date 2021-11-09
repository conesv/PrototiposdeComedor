using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PrototiposdeComedor
{
    class OracleDataBaseConexion
    {
        OracleConnection con;

        public void conect()
        {
            con = new OracleConnection();
            con.ConnectionString = "User Id = system; Password=Ariston7; Data Source=localhost";
            con.Open();
            Console.WriteLine("conected to Oracle" + con.ServerVersion);
        }
        public string comand(string str)
        {
            OracleCommand cmd = new OracleCommand(str);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetString(0);
        }
        public DataSet llenar(string str)
        {
            OracleCommand cmd = new OracleCommand(str);
            cmd.Connection = con;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            OracleCommandBuilder cb = new OracleCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void genericcmd(string str)
        {
            OracleCommand cmd = new OracleCommand(str);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
    }
}
