using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARC115ProyectoBiblioteca.entity
{
    class Devoluciones
    {
        public int id { get; set; }
        public Libro pklibro { get; set; }
        public Usuario pkusuario { get; set; }
        public int estado { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0} Detalles prestamo: Libro: {1} Usuario:{2}", 
                id, pklibro.titulo, pkusuario.nombre);
        }
    }
}
