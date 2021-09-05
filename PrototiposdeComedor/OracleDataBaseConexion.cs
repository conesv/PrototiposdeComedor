using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
