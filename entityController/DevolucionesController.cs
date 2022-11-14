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
    class DevolucionesController
    {

        public List<Devoluciones> findDevoluciones()
        {
            ConnectionDB conexion = new ConnectionDB();
            MySqlCommand commandDatabase = new MySqlCommand("select * from devoluciones ", conexion.open());
            List<Devoluciones> devoluciones = new List<Devoluciones>();


            MySqlDataReader reader = commandDatabase.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Devoluciones devolucion = new Devoluciones();
                    devolucion.id = int.Parse(reader.GetString(0));
                    devolucion.estado = int.Parse(reader.GetString(1));
                    devolucion.pklibro = new LibroController().findLibro(int.Parse(reader.GetString(2)));
                    devolucion.pkusuario = new UsuarioControlle().findUsuario(int.Parse(reader.GetString(3)));
                    devolucion.fechaEntrega = DateTime.Parse(reader.GetString(4));
                    devolucion.fechaPrestamo = DateTime.Parse(reader.GetString(5));
                    devoluciones.Add(devolucion);
                }
            }
            conexion.close();
            return devoluciones;
        }
        public DataTable findDevolucionesTable()
        {
            ConnectionDB conexion = new ConnectionDB();
            MySqlCommand cmd = new MySqlCommand("select * from devoluciones ", conexion.open());

            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable tabla = new DataTable();
            
            tabla.Columns.Add("ID");
            tabla.Columns.Add("Libro");
            tabla.Columns.Add("Autor");
            tabla.Columns.Add("ISBN");
            tabla.Columns.Add("DUI");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            tabla.Columns.Add("Fecha de entrega");
            tabla.Columns.Add("Fecha de prestado");

            if (reader.HasRows)
            {
                Object[] row = new Object[9];
                while (reader.Read())
                {
                    row[0] = int.Parse(reader.GetString(0));
                    row[1] = new LibroController().findLibro(int.Parse(reader.GetString(2))).titulo;
                    row[2] = new LibroController().findLibro(int.Parse(reader.GetString(2))).autor;
                    row[3] = new LibroController().findLibro(int.Parse(reader.GetString(2))).ISBN;
                    row[4] = new UsuarioControlle().findUsuario(int.Parse(reader.GetString(3))).dui;
                    row[5] = new UsuarioControlle().findUsuario(int.Parse(reader.GetString(3))).nombre;
                    row[6] = new UsuarioControlle().findUsuario(int.Parse(reader.GetString(3))).apellido;
                    row[7] = String.Format("{0:yyyy-MM-dd}", DateTime.Parse(reader.GetString(4)));
                    row[8] = String.Format("{0:yyyy-MM-dd}", DateTime.Parse(reader.GetString(5)));
                    tabla.Rows.Add(row);
                }
            }
            //MySqlDataReader resultado = cmd.ExecuteReader();
            //tabla.Load(resultado);

            conexion.close();
            return tabla;
        }

        public Devoluciones findDevolucion(int id)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("select * from devoluciones where id={0} ", id);
            MySqlCommand cmd = new MySqlCommand(query, conexion.open());
            Devoluciones devolucion = new Devoluciones();

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    devolucion.id = int.Parse(reader.GetString(0));
                    devolucion.estado = int.Parse(reader.GetString(1));
                    devolucion.pklibro = new LibroController().findLibro(int.Parse(reader.GetString(2)));
                    devolucion.pkusuario = new UsuarioControlle().findUsuario(int.Parse(reader.GetString(3)));
                    devolucion.fechaEntrega = DateTime.Parse(reader.GetString(4));
                    devolucion.fechaPrestamo = DateTime.Parse(reader.GetString(5));
                }
            }
            conexion.close();
            return devolucion;
        }

        public void addDevolucion(Devoluciones devolucione)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format(
                "insert into devoluciones (estado, pklibro, pkusuario, fechaEntrega, fechaprestamo) " +
                "values ({0}, {1}, {2}, '{3}', '{4}')",
                devolucione.estado, devolucione.pklibro.id, devolucione.pkusuario.id,
                String.Format("{0:yyyy-MM-dd}", devolucione.fechaEntrega),
                String.Format("{0:yyyy-MM-dd}", devolucione.fechaPrestamo));

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

        public void upadateDevoluciones(Devoluciones devolucione)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("update devoluciones " +
                "set estado='{1}', pklibro='{2}', pkusuario={3}, fechaEntrega='{4}', fechaprestamo='{5}' " +
                "where id={0}",
                devolucione.id, devolucione.estado, devolucione.pklibro.id, devolucione.pkusuario.id,
                String.Format("{0:yyyy-MM-dd}", devolucione.fechaEntrega),
                String.Format("{0:yyyy-MM-dd}", devolucione.fechaPrestamo));

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

        public void deleteDevoluciones(Devoluciones devolucione)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("delete from devoluciones where id={0}", devolucione.id);

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
