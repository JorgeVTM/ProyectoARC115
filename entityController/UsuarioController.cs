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
    public class UsuarioControlle
    {

        public List<Usuario> findUsuarios()
        {
            ConnectionDB conexion = new ConnectionDB();
            MySqlCommand commandDatabase = new MySqlCommand("select * from usuarios", conexion.open());
            List<Usuario> usuarios = new List<Usuario>();
            
            MySqlDataReader reader = commandDatabase.ExecuteReader();
           
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.id = int.Parse(reader.GetString(0));
                    usuario.nombre = reader.GetString(1);
                    usuario.apellido = reader.GetString(2);
                    usuario.carnet = reader.GetString(3);
                    usuario.fechanac = DateTime.Parse(reader.GetString(4));
                    usuario.correo = reader.GetString(5);
                    usuario.dui = reader.GetString(6);
                    usuario.telefono = reader.GetString(7);
                    usuario.rifd = reader.GetString(8);
                    usuarios.Add(usuario);
                }
            }
            conexion.close();
            return usuarios;
        }

        public DataTable findUsuariosTable()
        {
            ConnectionDB conexion = new ConnectionDB();
            MySqlCommand cmd = new MySqlCommand("select * from usuarios", conexion.open());

            MySqlDataReader resultado = cmd.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(resultado);
            conexion.close();
            return tabla;
        }

        public Usuario findUsuario(int id)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("select * from usuarios where id={0}",id);
            MySqlCommand cmd = new MySqlCommand(query, conexion.open());
            Usuario usuario = new Usuario();
            
            MySqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    usuario.id = int.Parse(reader.GetString(0));
                    usuario.nombre = reader.GetString(1);
                    usuario.apellido = reader.GetString(2);
                    usuario.carnet = reader.GetString(3);
                    usuario.fechanac = DateTime.Parse(reader.GetString(4));
                    usuario.correo = reader.GetString(5);
                    usuario.dui = reader.GetString(6);
                    usuario.telefono = reader.GetString(7);
                    usuario.rifd = reader.GetString(8);
                }
            }
            conexion.close();
            return usuario;
        }

        public void addUsuario(Usuario usuario)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format(
                "insert into usuarios (nombre, apellido, carnet, fecha, correo, dui, telefono, rifd)" +
                "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                usuario.nombre, usuario.apellido, usuario.carnet, String.Format("{0:yyyy-MM-dd}", usuario.fechanac),
                usuario.correo, usuario.dui, usuario.telefono, usuario.rifd
                );

            try {
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

        public void updateUsuario(Usuario usuario)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("update usuarios " +
                "set nombre='{1}', apellido='{2}', carnet='{3}', fecha='{4}', correo='{5}', dui='{6}', telefono='{7}', rifd='{8}' " +
                "where id={0}",
                usuario.id, usuario.nombre, usuario.apellido, usuario.carnet, String.Format("{0:yyyy-MM-dd}", usuario.fechanac),
                usuario.correo, usuario.dui, usuario.telefono, usuario.rifd
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

        public void deleteUsuario(Usuario usuario)
        {
            ConnectionDB conexion = new ConnectionDB();
            string query = string.Format("delete from usuarios where id={0}", usuario.id);

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
