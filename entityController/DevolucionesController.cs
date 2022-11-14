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

            MySqlDataReader resultado = cmd.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(resultado);
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
                }
            }
            conexion.close();
            return devolucion;
        }

        public void addDevolucion(Devoluciones devolucione)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format(
                "insert into devoluciones (estado, pklibro, pkusuario) " +
                "values ({0}, {1}, {2})",
                devolucione.estado, devolucione.pklibro.id, devolucione.pkusuario.id
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

        public void upadateDevoluciones(Devoluciones devolucione)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("update devoluciones " +
                "set estado='{1}', pklibro='{2}', pkusuario={3} " +
                "where id={0}",
                devolucione.id, devolucione.estado, devolucione.pklibro.id, devolucione.pkusuario.id);

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
