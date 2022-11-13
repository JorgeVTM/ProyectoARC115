using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARC115ProyectoBiblioteca.entity
{
    class LibrosPrestamos
    {
        public int id { get; set; }
        public Libro pklibro { get; set; }
        public Usuario pkusuario { get; set; }
        public DateTime fechaPrestamo { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public int estado { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0} Usuario: {1} Libro: {2}", id, pkusuario.ToString(), pklibro.ToString());
        }
    }
}
