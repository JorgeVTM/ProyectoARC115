using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARC115ProyectoBiblioteca.entity
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(string nombre, string apellido,  string carnet, DateTime date, string correo,  string dui, string telefono, string rifd) 
        {
            //this.id = id;
            this.nombre = nombre;
            this.carnet = carnet;
            this.apellido = apellido;
            this.fechanac = date;
            this.correo = correo;
            this.dui = dui;
            this.telefono = telefono;
            this.rifd = rifd;
        }

        public int id
        {
            get;
            set;
        }

        public string nombre
        {
            get;
            set;
        }

        public string carnet
        {
            get;
            set;
        }

        public DateTime fechanac
        {
            get;
            set;
        }

        public string correo
        {
            get;
            set;
        }

        public string apellido
        {
            get;
            set;
        }

        public string dui
        {
            get;
            set;
        }

        public string telefono
        {
            get;
            set;
        }

        public string rifd
        {
            get;
            set;
        }

        public override String ToString()
        {
            return String.Format("id: {0}, nombre: {1}", id,nombre); 
        }
    }
}
