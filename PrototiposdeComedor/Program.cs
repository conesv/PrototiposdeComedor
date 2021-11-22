using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototiposdeComedor
{

    static class Program
    {
        public static string globales1;
        public static string date = DateTime.Now.ToString();
        public static string usuario;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepcion " + e + " No contralada, consulte a soporte");
            }
            
        }
    }
}
