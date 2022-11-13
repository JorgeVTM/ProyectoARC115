using ARC115ProyectoBiblioteca.entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARC115ProyectoBiblioteca.entityController
{
    class LibrosPrestamosController
    {

        public List<LibrosPrestamos> findPrestamos()
        {
            ConnectionDB conexion = new ConnectionDB();
            MySqlCommand commandDatabase = new MySqlCommand("select * from libros_prestamos ", conexion.open());
            List<LibrosPrestamos> prestamos = new List<LibrosPrestamos>();


            MySqlDataReader reader = commandDatabase.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LibrosPrestamos prestamo = new LibrosPrestamos();
                    prestamo.id = int.Parse(reader.GetString(0));
                    prestamo.pklibro = new LibroController().findLibro(int.Parse(reader.GetString(1)));
                    prestamo.pkusuario = new UsuarioControlle().findUsuario(int.Parse(reader.GetString(2)));
                    prestamo.fechaPrestamo = DateTime.Parse(reader.GetString(4));
                    prestamo.fechaDevolucion = DateTime.Parse(reader.GetString(4));
                    prestamo.estado = int.Parse(reader.GetString(6));
                    prestamos.Add(prestamo);
                }
            }
            conexion.close();
            return prestamos;
        }
        public DataTable findPrestamosTable()
        {
            ConnectionDB conexion = new ConnectionDB();
            MySqlCommand cmd = new MySqlCommand("select * from libros_prestamos ", conexion.open());

            MySqlDataReader resultado = cmd.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(resultado);
            conexion.close();
            return tabla;
        }

        public LibrosPrestamos findPrestamo(int id)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("select * from libros_prestamos where id={0} ", id);
            MySqlCommand cmd = new MySqlCommand(query, conexion.open());
            LibrosPrestamos prestamo = new LibrosPrestamos();

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    prestamo.id = int.Parse(reader.GetString(0));
                    prestamo.pklibro = new LibroController().findLibro(int.Parse(reader.GetString(1)));
                    prestamo.pkusuario = new UsuarioControlle().findUsuario(int.Parse(reader.GetString(2)));
                    prestamo.fechaPrestamo = DateTime.Parse(reader.GetString(4));
                    prestamo.fechaDevolucion = DateTime.Parse(reader.GetString(4));
                    prestamo.estado = int.Parse(reader.GetString(6));
                }
            }
            conexion.close();
            return prestamo;
        }

        public void addPrestamo(LibrosPrestamos prestamos)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format(
                "insert into libros_prestamos (pklibro, pkusuario, fechaprestamo, fechadevolucion, estado) " +
                "values ('{0}', '{1}', '{2}', '{3}', '{4}')",
                prestamos.pklibro.id, prestamos.pkusuario.id, String.Format("{0:yyyy-MM-dd}", prestamos.fechaPrestamo),
                String.Format("{0:yyyy-MM-dd}", prestamos.fechaDevolucion), prestamos.estado
                );

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion.open());
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Done");
            conexion.close();
        }

        public void updatePrestamo(LibrosPrestamos prestamos)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("update libros_prestamos " +
                "set pklibro='{1}', pkusuario='{2}', fechaprestamo='{3}', fechadevolucion='{4}', estado='{5}' " +
                "where id={0}",
                prestamos.pklibro.id, prestamos.pkusuario.id, String.Format("{0:yyyy-MM-dd}", prestamos.fechaPrestamo),
                String.Format("{0:yyyy-MM-dd}", prestamos.fechaDevolucion), prestamos.estado
                );

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion.open());
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Done");
            conexion.close();
        }

        public void deletePrestamo(LibrosPrestamos prestamos)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("delete from libros_prestamos where id={0}", prestamos.id);

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion.open());
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Done");
            conexion.close();
        }
    }
}
