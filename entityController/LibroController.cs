using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARC115ProyectoBiblioteca.entity;
using MySql.Data.MySqlClient;

namespace ARC115ProyectoBiblioteca.entityController
{
    public class LibroController
    {

        public List<Libro> findLibros()
        {
            ConnectionDB conexion = new ConnectionDB();
            MySqlCommand commandDatabase = new MySqlCommand("select * from libros ", conexion.open());
            List<Libro> libros = new List<Libro>();

            MySqlDataReader reader = commandDatabase.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Libro libro = new Libro();
                    libro.id = int.Parse(reader.GetString(0));
                    libro.ISDBN = reader.GetString(1);
                    libro.titulo = reader.GetString(2);
                    libro.fechapublicacion = DateTime.Parse(reader.GetString(4));
                    libro.autor = reader.GetString(5);
                    libro.editorial = reader.GetString(6);
                    libro.categoria = reader.GetString(7);
                    libros.Add(libro);
                }
            }
            conexion.close();
            return libros;
        }
        public DataTable findLibrosTable()
        {
            ConnectionDB conexion = new ConnectionDB();
            MySqlCommand cmd = new MySqlCommand("select * from libros ", conexion.open());

            MySqlDataReader resultado = cmd.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(resultado);
            conexion.close();
            return tabla;
        }

        public Libro findLibro(int id)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("select * from libros where id={0} ", id);
            MySqlCommand cmd = new MySqlCommand(query, conexion.open());
            Libro libro = new Libro();

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    libro.id = int.Parse(reader.GetString(0));
                    libro.ISDBN = reader.GetString(1);
                    libro.titulo = reader.GetString(2);
                    libro.fechapublicacion = DateTime.Parse(reader.GetString(4));
                    libro.autor = reader.GetString(5);
                    libro.editorial = reader.GetString(6);
                    libro.categoria = reader.GetString(7);
                }
            }
            conexion.close();
            return libro;
        }

        public void addLibro(Libro libro)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format(
                "insert into libros (isbn, titulo, fechapublicacion, autor, editorial, categoria) " +
                "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                libro.ISDBN, libro.titulo, String.Format("{0:yyyy-MM-dd}", libro.fechapublicacion),
                libro.autor, libro.editorial, libro.categoria
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

        public void upadateLibro(Libro libro)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("update libros " +
                "set isbn='{1}', titulo='{2}', fechapublicacion='{3}', autor='{4}', editorial='{5}', categoria='{6}' " +
                "where id={0}",
                libro.id, libro.ISDBN, libro.titulo, String.Format("{0:yyyy-MM-dd}", libro.fechapublicacion),
                libro.autor, libro.editorial, libro.categoria
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

        public void deleteLibro(Libro libro)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("delete from libros where id={0} ", libro.id);

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
