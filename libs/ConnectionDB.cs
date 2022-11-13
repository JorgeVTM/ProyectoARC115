using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ARC115ProyectoBiblioteca
{
    internal class ConnectionDB
    {
        
        private string myConnectionString;

        private MySqlConnection conexion;

        public ConnectionDB() { 
        
        }

        //Conexion a la base de datos
        public MySqlConnection open()
        {
            this.myConnectionString = "datasource=127.0.0.1;port=3306;username=username;password=user12345;database=arc115biblioteca;";

            try
            {
                this.conexion = new MySqlConnection(myConnectionString);
                this.conexion.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            return conexion;
        }

        public void close()
        {
            try
            {
                this.conexion.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
        }



        public void listUsers()
        {
            string myConnectionString = "datasource=127.0.0.1;port=3306;username=username;password=user12345;database=arc115biblioteca;";
            // Select all
            string query = "SELECT * FROM usuarios";

            MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // Success, now list 

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

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
