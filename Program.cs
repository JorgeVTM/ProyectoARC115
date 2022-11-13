using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARC115ProyectoBiblioteca
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConnectionDB conexion = new ConnectionDB();
            MySqlCommand commandDatabase = new MySqlCommand("select * from usuarios", conexion.open());
            
            MySqlDataReader reader = commandDatabase.ExecuteReader();
            // If there are available rows
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            conexion.close();
            //conexion.listUsers();
            //Application.EnableVisualStyles();
            ///Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Base());
        }
    }
}
